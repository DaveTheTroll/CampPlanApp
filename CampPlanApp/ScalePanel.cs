using System.ComponentModel;

namespace CampPlanApp
{
    public abstract class ScalePanel : Panel
    {
        Point offset = new Point(0, 0);
        float scale = 1;

        [DefaultValue(true)]
        public bool Grid { get; set; } = true;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            RectangleF limits = ContentsLimits;
            float unitScale = Math.Min(Width / limits.Width, Height / limits.Height);   // units/px
            g.TranslateTransform(offset.X + Width / 2, offset.Y + Height / 2);
            g.ScaleTransform(scale * unitScale, -scale * unitScale);
            g.TranslateTransform(-(limits.Left + limits.Right) / 2, -(limits.Top + limits.Bottom) / 2);

            if (Grid)
                PaintGrid(g, unitScale);

            Render(g);
        }

        public PointF ScaledLocation(Point pnt)
        {
            RectangleF limits = ContentsLimits;
            float unitScale = Math.Min(Width / limits.Width, Height / limits.Height);   // units/px
            /*
            float x = (pnt.X + (limits.Left + limits.Right) / 2) * unitScale/scale - offset.X - Width/2;
            float y = (pnt.Y + (limits.Top + limits.Bottom) / 2) * unitScale/scale - offset.Y - Height/2;
            */
            float x = ((pnt.X - Width / 2 - offset.X) / scale / unitScale) + (limits.Left + limits.Right) / 2;
            float y = ((pnt.Y - Height / 2 - offset.Y) / -scale / unitScale) + (limits.Top + limits.Bottom) / 2;
            return new PointF(x, y);
        }

        void PaintGrid(Graphics g, float unitScale)
        {
            Pen pen = new Pen(Color.FromArgb(50, Color.Black), 1 / unitScale);
            for(int x=-10; x<=10; x++)
            {
                g.DrawLine(pen, x, -10, x, 10);
                g.DrawLine(pen, -10, x, 10, x);
            }
        }

        protected abstract void Render(Graphics g);
        protected abstract RectangleF ContentsLimits { get; }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        #region Mouse
        Point? dragStart;
        Point offsetStart;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Middle)
            {
                dragStart = e.Location;
                offsetStart = offset;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Middle)
            {
                dragStart = null;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (dragStart != null)
            {
                offset = new Point(offsetStart.X + (e.Location.X - dragStart.Value.X),
                                    offsetStart.Y + (e.Location.Y - dragStart.Value.Y));
                Invalidate();
            }
            ScaledMouseMove?.Invoke(new ScaledMouseEventArgs(e, this));
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            float factor = (float)Math.Pow(0.9f, -e.Delta / 200.0);
            scale *= factor;
            Invalidate();
        }
        #endregion

        public event ScaledMouseEvent ScaledMouseMove;
    }

    public class ScaledMouseEventArgs : MouseEventArgs
    {
        internal ScaledMouseEventArgs(MouseEventArgs e, ScalePanel panel)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            this.panel = panel;
        }

        ScalePanel panel;
        public PointF ScaledLocation => panel.ScaledLocation(Location);
    }

    public delegate void ScaledMouseEvent(ScaledMouseEventArgs e);
}

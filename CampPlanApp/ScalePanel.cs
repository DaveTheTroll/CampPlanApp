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
            g.TranslateTransform(offset.X + Width / 2, offset.Y + Height / 2);
            g.ScaleTransform(scale, -scale);
            g.TranslateTransform(-(limits.Left + limits.Right) / 2, -(limits.Top + limits.Bottom) / 2);

            if (Grid)
                PaintGrid(g);

            Render(g);
        }

        public void ZoomToContents()
        {
            RectangleF limits = ContentsLimits;
            scale = Math.Min(Width / limits.Width, Height / limits.Height);
            offset = limits.Centre().ToPoint();
        }

        public PointF ScaledLocation(Point pnt)
        {
            float x = ((pnt.X - Width / 2 - offset.X) / scale);
            float y = ((pnt.Y - Height / 2 - offset.Y) / -scale);
            return new PointF(x, y);
        }

        void PaintGrid(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(50, Color.Black), 1/scale);
            for(int x=-100; x<=100; x+=5)
            {
                g.DrawLine(pen, x, -100, x, 100);
                g.DrawLine(pen, -100, x, 100, x);
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
            float oldScale = scale;
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

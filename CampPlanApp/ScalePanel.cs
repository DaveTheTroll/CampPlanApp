namespace CampPlanApp
{
    public abstract class ScalePanel : Panel
    {
        Point offset = new Point(0, 0);
        float scale = 1; 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RectangleF limits = ContentsLimits;
            float unitScale = Math.Min(Width/limits.Width, Height/limits.Height);   // units/px
            e.Graphics.TranslateTransform(offset.X + Width/2, offset.Y + Height/2);
            e.Graphics.ScaleTransform(scale * unitScale, -scale * unitScale);
            e.Graphics.TranslateTransform(-(limits.Left+limits.Right)/2, -(limits.Top+limits.Bottom)/2);

            Render(e.Graphics);
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
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            float factor = (float)Math.Pow(0.9f, -e.Delta / 200.0);
            scale *= factor;
            Invalidate();
        }
        #endregion
    }
}

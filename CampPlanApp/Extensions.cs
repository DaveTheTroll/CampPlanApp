namespace CampPlanApp
{
    public static class Extensions
    {
        public static void DrawRectangle(this Graphics g, Pen pen, RectangleF rect)
        {
            g.DrawRectangles(pen, new[] { rect });
        }

        public static PointF Centre(this RectangleF rc) => new PointF((rc.Left + rc.Right) / 2, (rc.Top + rc.Bottom) / 2);
        public static RectangleF AsFloat(this Rectangle rc) => new RectangleF(rc.Left, rc.Top, rc.Width, rc.Height);
        public static PointF Centre(this Rectangle rc) => rc.AsFloat().Centre();
        public static Point ToPoint(this PointF pnt) => new Point((int)(pnt.X + 0.5f), (int)(pnt.Y + 0.5f));
    }
}

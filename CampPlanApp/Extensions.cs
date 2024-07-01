namespace CampPlanApp
{
    public static class Extensions
    {
        public static void DrawRectangle(this Graphics g, Pen pen, RectangleF rect)
        {
            g.DrawRectangles(pen, new[] { rect });
        }
    }
}

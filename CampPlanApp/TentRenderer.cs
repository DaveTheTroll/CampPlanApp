namespace CampPlanApp
{
    public static class TentRenderer
    {
        static Brush guyBrush = new SolidBrush(Color.FromArgb(50, Color.Black));
        public static void Render(Graphics g, Tent tent)
        {
            RectangleF bounds = tent.Bounds;
            RectangleF guyBounds = tent.GuyBounds;
            Brush brush = new SolidBrush(tent.Color);
            switch(tent.Type.Shape)
            {
                case TentType._Shape.Square:
                    g.FillRectangle(guyBrush, guyBounds);
                    g.FillRectangle(brush, bounds);
                    break;
                case TentType._Shape.Circle:
                    g.FillEllipse(guyBrush, guyBounds);
                    g.FillEllipse(brush, bounds);
                    break;
            }
        }
    }
}

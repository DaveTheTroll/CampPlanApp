using System.Drawing.Drawing2D;

namespace CampPlanApp
{
    public static class TentRenderer
    {
        static Brush guyBrush = new SolidBrush(Color.FromArgb(50, Color.Black));
        static Pen selectedPen = new Pen(Color.Black, 0.1f);

        static TentRenderer()
        {
            selectedPen.DashStyle = DashStyle.DashDot;
        }
        public static void Render(Graphics g, Tent tent, bool selected)
        {
            RectangleF bounds = tent.Bounds;
            RectangleF guyBounds = tent.GuyBounds;
            Brush brush = new SolidBrush(tent.Color);
            switch(tent.Type.Shape)
            {
                case TentType._Shape.Square:
                    g.FillRectangle(guyBrush, guyBounds);
                    g.FillRectangle(brush, bounds);
                    if (selected)
                    {
                        g.DrawRectangle(selectedPen, bounds);
                    }
                    break;
                case TentType._Shape.Circle:
                    g.FillEllipse(guyBrush, guyBounds);
                    g.FillEllipse(brush, bounds);
                    if (selected)
                    {
                        g.DrawEllipse(selectedPen, bounds);
                    }
                    break;
            }
        }
    }
}

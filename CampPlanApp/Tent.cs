namespace CampPlanApp
{
    public class TentType
    {
        public TentType(SizeF size, _Shape shape, float guys = 1.5f)
        {
            this.Size = size;
            this.Shape = shape;
            this.Guys = guys;
        }
        public SizeF Size { get; set; }
        public float Guys { get; set; }
        public _Shape Shape { get; set; }

        public enum _Shape
        {
            Circle, Square
        }
    }

    public class Tent
    {
        public Tent(string name, TentType type, Color color, PointF? location=null, float rotation=0)
        {
            this.Name = name;
            this.Type = type;
            this.Color = color;
            this.Location = location;
            this.Rotation = rotation;
        }
        public string Name { get; set; }
        public TentType Type { get; set; }
        public PointF? Location { get; set; }
        public float Rotation { get; set; }
        public bool HasLocation => Location.HasValue;
        public Color Color { get; set; }

        public RectangleF Bounds => Location.HasValue ? new RectangleF(Location.Value.X - Type.Size.Width / 2, Location.Value.Y - Type.Size.Height / 2, Type.Size.Width, Type.Size.Height) : RectangleF.Empty;
        public RectangleF GuyBounds => Location.HasValue ? new RectangleF(Location.Value.X - Type.Size.Width / 2 - Type.Guys, Location.Value.Y - Type.Size.Height / 2 - Type.Guys, Type.Size.Width + Type.Guys*2, Type.Size.Height + Type.Guys * 2) : RectangleF.Empty;

        public bool Contains(PointF pnt) => Bounds.Contains(pnt);
    }
}

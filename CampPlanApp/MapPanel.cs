namespace CampPlanApp
{
    public class MapPanel : ScalePanel
    {
        protected override RectangleF ContentsLimits => new RectangleF(-20, -20, 80, 40);

        protected override void Render(Graphics g)
        {
            if (Tents != null)
            {
                foreach (Tent tent in Tents)
                {
                    if (tent.HasLocation)
                    {
                        TentRenderer.Render(g, tent, SelectedTents.Contains(tent));
                    }
                }
            }
        }

        public IList<Tent> Tents {get; set;}
        List<Tent> SelectedTents { get; } = new List<Tent>();

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);/*
            bool changed = false;
            PointF pnt = ScaledLocation(e.Location);
            foreach(Tent tent in Tents.Reverse())
            {
                if (tent.Hit(pnt))
                {
                    // Toggle selected state of tent
                    changed = true;
                    break;
                }
            }
            if (changed)
            {
                Invalidate();
            }*/
        }
    }
}

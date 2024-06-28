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
                        TentRenderer.Render(g, tent);
                    }
                }
            }
        }

        public IList<Tent> Tents {get; set;}
    }
}

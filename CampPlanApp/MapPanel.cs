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

        public bool Selected(Tent tent) => SelectedTents.Contains(tent);
        public void SetSelection(IEnumerable<Tent> selection)
        {
            SelectedTents.Clear();
            SelectedTents.AddRange(selection);
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                bool changed = false;
                PointF pnt = ScaledLocation(e.Location);
                foreach (Tent tent in Tents.Reverse())
                {
                    if (tent.Contains(pnt))
                    {
                        // Toggle selected state of tent
                        changed = true;
                        ToggleSelection(tent);
                        break;
                    }
                }
                if (changed)
                {
                    Invalidate();
                    SelectionChanged?.Invoke(this);
                }
            }
        }

        void ToggleSelection(Tent tent)
        {
            if (Selected(tent))
            {
                SelectedTents.Remove(tent);
            }
            else
            {
                SelectedTents.Add(tent);
            }
        }

        public event Action<MapPanel> SelectionChanged;
    }
}

namespace CampPlanApp
{
    public class MapPanel : ScalePanel
    {
        protected override RectangleF ContentsLimits
        {
            get
            {
                if (Tents == null)
                {
                    return new RectangleF(-10, -10, 20, 20);
                }
                IEnumerable<Tent> tents = Tents.Where(t => t.HasLocation);
                if (!tents.Any())
                {
                    return new RectangleF(-10, -10, 20, 20);
                }

                RectangleF rc = new RectangleF(tents.First().Bounds.Left, tents.First().Bounds.Top, 0, 0);
                foreach(Tent tent in tents)
                {
                    rc = RectangleF.Union(rc, tent.GuyBounds);
                }
                return rc;
            }
        }

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

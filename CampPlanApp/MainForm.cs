namespace CampPlanApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
        }

        void testDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.Tents = new List<Tent>();
            TentType bell5 = new TentType(new SizeF(5,5), TentType._Shape.Circle);
            TentType pavilion = new TentType(new SizeF(5,5), TentType._Shape.Square);
            map.Tents.Add(new Tent("Bell5", bell5, Color.White));
            map.Tents.Add(new Tent("Pavilion", pavilion, Color.White));
            map.Tents.Add(new Tent("Cream Pavilion", pavilion, Color.Beige, new PointF(0,0)));
            map.Invalidate();
            RefreshTentList();
        }

        void map_ScaledMouseMove(ScaledMouseEventArgs e)
        {
            PointF loc = e.ScaledLocation;
            toolStripStatusLabelLocation.Text = $"{loc.X:0.0}, {loc.Y:0.0}";
        }

        void RefreshTentList()
        {
            listViewTents.Items.Clear();
            foreach(Tent tent in map.Tents)
            {
                ListViewItem item = listViewTents.Items.Add(tent.Name);
                item.Tag = tent;
                item.Selected = map.Selected(tent);
            }
        }

        void RefreshTentListSelection()
        {
            foreach(ListViewItem item in listViewTents.Items)
            {
                item.Selected = map.Selected((Tent)item.Tag);
            }
        }

        void map_SelectionChanged(MapPanel obj)
        {
            RefreshTentListSelection();
        }

        void listViewTents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            map.SetSelection(listViewTents.SelectedItems.Cast<ListViewItem>().Select(item => (Tent)item.Tag));
        }
    }
}
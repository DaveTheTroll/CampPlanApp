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
            map.Tents.Add(new Tent(bell5, Color.White));
            map.Tents.Add(new Tent(pavilion, Color.White));
            map.Tents.Add(new Tent(pavilion, Color.Beige, new PointF(0,0)));
            map.Invalidate();
        }

        void map_ScaledMouseMove(ScaledMouseEventArgs e)
        {
            PointF loc = e.ScaledLocation;
            toolStripStatusLabelLocation.Text = $"{loc.X:0.0}, {loc.Y:0.0}";
        }
    }
}
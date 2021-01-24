    public partial class Form1 : Form
    {
        public Form1()
        {
            // just add a PictureBox on the Winform.
            InitializeComponent();
            DrawMap();
        }
        private void DrawMap()
        {
            Session.Instance.SetCoordinateSystemServices(
                new CoordinateSystemServices(
                        new CoordinateSystemFactory(),
                        new CoordinateTransformationFactory(),
                        SpatialReference.GetAllReferenceSystems()));
            var map = new Map(pictureBox1.Size);
            map.BackColor = Color.White;
            var file = new ShapeFile(@"D:\Downloads\FRA_adm\FRA_adm1.shp", true);
            var layer = new VectorLayer("France", file);
            map.Layers.Add(layer);
            map.ZoomToExtents();
            pictureBox1.Image = map.GetMap();
        }
    }
    

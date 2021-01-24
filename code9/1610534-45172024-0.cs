    public partial class RadarForm : Form
    {
        //A List to hold our blips
        private List<RadarBlip> blips = new List<RadarBlip>();
        //Random number generator
        private Random random = new Random();
        public RadarForm()
        {
            InitializeComponent();
            //Setting to prevent flickering when redrawing the graphics
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Set the graphics quality to high quality
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Set the origin of the Cartesian plane to the center of the form
            resetOrigin(e.Graphics);
            //draw "danger" circle.  This would be your 15 meter circle
            drawCircle(new Point(0, 0), 200, 3, Color.Red, e.Graphics);
            //Draw X and Y Axes
            using (var p = new Pen(Brushes.Black, 3.0F))
            {
                //Draw X axis
                e.Graphics.DrawLine(p, new Point(-Width / 2, 0), new Point(Width / 2, 0));
                //Draw Y axis
                e.Graphics.DrawLine(p, new Point(0, -Height / 2), new Point(0, Height / 2));
            }
            //Draw all the radar blips in the collection  red = enemy blue = friendly.  
            //Each blip is drawn 10 pixels in size.
            foreach (var blip in blips)
            {
                Brush b = blip.IsEnemy ? Brushes.Red : Brushes.Blue;
                e.Graphics.FillEllipse(b, blip.X - 5, blip.Y - 5, 10, 10);
            }
        }
        //Create a random radar blip.  50/50 chance of being an enemy
        private RadarBlip createRandomBlip()
        {
            return new RadarBlip
            {
                X = random.Next(-Width / 2, Width / 2 + 1),
                Y = random.Next(-Height / 2, Height / 2 + 1),
                IsEnemy = random.Next(0, 101) > 50
            };
        }
        private void resetOrigin(Graphics g)
        {
            // Flip the Y-Axis so that positive values are upward on the axis
            g.ScaleTransform(1.0F, -1.0F);
            // Translate the drawing area accordingly so the origin is in the center of the form
            g.TranslateTransform(Width / 2.0F, -Height / 2.0F);
        }
        private void drawCircle(Point center, int radius, int thickness, Color color, Graphics g)
        {
            var rect = new Rectangle(center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
            using (var p = new Pen(color, thickness))
            {
                g.DrawEllipse(p, rect);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            blips.Add(createRandomBlip());
            this.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            blips.Clear();
            this.Refresh();
        }
    }
    public class RadarBlip
    {
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsEnemy { get; set; }
    }

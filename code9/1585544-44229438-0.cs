    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private PointF[] nPoints;
        private PointF[] triangle;
        private int sides = 5;
        private int angle = 0;
        private int radius = 100;
        private int triangleLength = 10;
        private void Form1_Load(object sender, EventArgs e)
        {
            triangle = this.CalculateVertices(3, triangleLength, 0, new Point(0, 0)); // this "unit triangle" will get reused!
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Point center = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            nPoints = CalculateVertices(sides, radius, angle, center);
            // draw the polygon
            g.FillPolygon(Brushes.Blue, nPoints);
            g.DrawPolygon(Pens.Black, nPoints);                  
            for (int i = 0; i < sides; i++)
            {
                g.DrawLine(Pens.Black, center.X, center.Y, nPoints[i].X, nPoints[i].Y);
            }
            // draw small triangles on each edge:
            float step = 360.0f / sides;
            float curAngle = angle + step / 2; // start in-between the original angles
            for (double i = curAngle; i < angle + (step / 2) + 360.0; i += step) //go in a circle
            {
                // move to the center and rotate:
                g.ResetTransform();
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform((float)i);
                // move out to where the triangle will be drawn and render it
                g.TranslateTransform(radius, 0);
                g.FillPolygon(Brushes.LightGreen, triangle);
                g.DrawPolygon(Pens.Black, triangle);
            }
        }
        // this is your code unchanged
        private PointF[] CalculateVertices(int sides, int radius, float startingAngle, Point center)
        {
            if (sides < 3)
            {
                sides = 3;
            }
            //throw new ArgumentException("Polygon must have 3 sides or more.");
            List<PointF> points = new List<PointF>();
            float step = 360.0f / sides;
            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }
            return points.ToArray();
        }
        // this is your code unchanged
        private PointF DegreesToXY(float degrees, float radius, Point origin)
        {
            PointF xy = new PointF();
            double radians = degrees * Math.PI / 180.0;
            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);
            return xy;
        }
    }

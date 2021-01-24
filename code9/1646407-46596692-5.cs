    public partial class Form1 : Form
    {
        private bool isMoving = false;
        private Point mouseDownPosition = Point.Empty;
        private Point mouseMovePosition = Point.Empty;
        private List<Tuple<Point, Point>> lines = new List<Tuple<Point, Point>>();
        public Form1()
        {
            InitializeComponent();
            pen.CustomEndCap = bigArrow;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            mouseDownPosition = e.Location;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                mouseMovePosition = e.Location;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                lines.Add(Tuple.Create(mouseDownPosition, mouseMovePosition));
                pictureBox2.Invalidate();
            }
            isMoving = false;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isMoving)
            {
                if ((sender as PictureBox).Image == null) e.Graphics.Clear(Color.White);
                // Add this line for high quality drawing:
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawLine(pen, mouseDownPosition, mouseMovePosition);
                // If you want draw all previous lines here, add bellow code:
                //foreach (var line in lines)
                //{
                //    e.Graphics.DrawLine(pen, line.Item1, line.Item2);
                //}
            }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as PictureBox).Image == null) e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            foreach (var line in lines)
            {
                e.Graphics.DrawLine(pen, line.Item1, line.Item2);
            }
        }
    }

    public partial class Form1 : Form
    {
        private Bitmap _bitmap;
        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        private void TransformGraphics(Graphics g)
        {
            g.ResetTransform();
            g.TranslateTransform(_bitmap.Width / 2, _bitmap.Height / 2);
            g.RotateTransform(trackBar1.Value);
            g.TranslateTransform(-_bitmap.Width / 2, -_bitmap.Height / 2);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            TransformGraphics(e.Graphics);
            e.Graphics.DrawImage(_bitmap, new Point());
        }
        private Point? _previousPoint;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _previousPoint = e.Location;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _previousPoint = null;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previousPoint.HasValue)
            {
                using (Graphics g = Graphics.FromImage(_bitmap))
                {
                    TransformGraphics(g);
                    var matrix = g.Transform;
                    matrix.Invert();
                    var points = new[] { _previousPoint.Value, e.Location };
                    matrix.TransformPoints(points);
                    g.ResetTransform();
                    g.DrawLine(Pens.Black, points[0], points[1]);
                    pictureBox1.Invalidate();
                    _previousPoint = e.Location;
                }
            }
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }

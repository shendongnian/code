    public partial class Form1 : Form {
        private List<Point> _points = new List<Point>();
        private PictureBox _pictureBox1;
        private PictureBox _pictureBox2;
        private Button _button1;
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            Size = new Size(1366, 675);
            _pictureBox1 = new PictureBox {
                Location = new Point(12, 51),
                Size = new Size(651, 474),
                BorderStyle = BorderStyle.FixedSingle
            };
            _pictureBox2 = new PictureBox
            {
                Location = new Point(669, 51),
                Size = new Size(651, 474),
                BorderStyle = BorderStyle.FixedSingle
            };
            _button1 = new Button {
                Text = @"Copy selected area",
                Location = new Point(13, 13),
                Size = new Size(175, 23)
            };
            Controls.AddRange(new Control[] { _pictureBox1, _pictureBox2, _button1 });
            _pictureBox1.Image = Image.FromFile(@"d:\temp\Hopetoun_falls.jpg");
            _points = new List<Point>();
            _pictureBox1.MouseDown += delegate(object o, MouseEventArgs args) { _points.Add(args.Location); _pictureBox1.Refresh(); };
            _pictureBox1.Paint += pictureBox1_Paint;
            _button1.Click += button_Click;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            if (_points.Count < 2) {
                return;
            }
            var max = _points.Count;
            for (int i = 1; i < max; i++) {
                e.Graphics.DrawLine(Pens.Red, _points[i-1].X, _points[i-1].Y, _points[i].X, _points[i].Y);
            }
            e.Graphics.DrawLine(Pens.Red, _points[max - 1].X, _points[max - 1].Y, _points[0].X, _points[0].Y);
        }
        private static Bitmap GetSelectedArea(Image source, Color bgColor, List<Point> points) {
            var bigBm = new Bitmap(source);
            using (var gr = Graphics.FromImage(bigBm)) {
                // Set the background color.
                gr.Clear(bgColor);
                // Make a brush out of the original image.
                using (var br = new TextureBrush(source)) {
                    // Fill the selected area with the brush.
                    gr.FillPolygon(br, points.ToArray());
                    // Find the bounds of the selected area.
                    var sourceRect = GetPointListBounds(points);
                    // Make a bitmap that only holds the selected area.
                    var result = new Bitmap(sourceRect.Width, sourceRect.Height);
                    // Copy the selected area to the result bitmap.
                    using (var resultGr = Graphics.FromImage(result)) {
                        var destRect = new Rectangle(0, 0, sourceRect.Width, sourceRect.Height);
                        resultGr.DrawImage(bigBm, destRect, sourceRect, GraphicsUnit.Pixel);
                    }
                    // Return the result.
                    return result;
                }
            }
        }
        private static Rectangle GetPointListBounds(List<Point> points) {
            int xmin = points[0].X;
            int xmax = xmin;
            int ymin = points[0].Y;
            int ymax = ymin;
            for (int i = 1; i < points.Count; i++) {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
                if (ymin > points[i].Y) ymin = points[i].Y;
                if (ymax < points[i].Y) ymax = points[i].Y;
            }
            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }
        private void button_Click(object sender, EventArgs e) {
            if (_points.Count < 3) {
                return;
            }
            var img = GetSelectedArea(_pictureBox1.Image, Color.Transparent, _points);
            _pictureBox2.Image = img;
            _pictureBox2.Image.Save(@"d:\temp\sample.png", ImageFormat.Png);
        }
    }

    public partial class Form1 : Form
    {
        double zoom = 2.4;
        double centerX = -0.72, centerY = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private async void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double minX = centerX - zoom / 2, minY = centerY - zoom / 2;
            centerX = minX + (double)e.Location.X / pictureBox1.Width * zoom;
            centerY = minY + (double)e.Location.Y / pictureBox1.Height * zoom;
            zoom -= 0.3;
            await Mandelbrot();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Mandelbrot();
        }
        private async Task Mandelbrot()
        {
            IProgress<double> progress = new Progress<double>(x => label1.Text = $"{x * 100:0}% done");
            DateTime StartT = DateTime.UtcNow;
            pictureBox1.Image = await Task.Run(() => _GenerateBitmap(progress));
            DateTime EndT = DateTime.UtcNow;
            string Time = Convert.ToString((EndT - StartT).TotalSeconds);
            textBox1.Text = "Time Taken: " + Time + " Seconds";
        }
        private Bitmap _GenerateBitmap(IProgress<double> progress)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            double minX = centerX - zoom / 2, minY = centerY - zoom / 2;
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = minX + (double)x / pictureBox1.Width * zoom;
                    double b = minY + (double)y / pictureBox1.Height * zoom;
                    Complex C = new Complex(a, b);
                    Complex Z = new Complex(0, 0);
                    int u = 0;
                    do
                    {
                        u++;
                        Z = Z * Z;
                        Z = Z + C;
                        double Mag = Complex.Abs(Z);
                        if (Mag > 2.0) break;
                    } while (u < 255);
                    Color rgbInside = Color.FromArgb(0, 0, 0);
                    Color rgbOutside = Color.FromArgb(u >= 127 ? 255 : 2 * u, u >= 127 ? (u - 127) : 0, 0);
                    bm.SetPixel(x, y, u < 255 ? rgbOutside : rgbInside);
                }
                progress.Report((double)x / pictureBox1.Width);
            }
            return bm;
        }
        private async void button1_Click_1(object sender, EventArgs e)
        {
            zoom = 2.4;
            await Mandelbrot();
        }
    }

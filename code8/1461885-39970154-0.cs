    public partial class Form1 : Form
    {
        const int maxCircleCount = 30;
        List<int> circles = new List<int>();
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Arguably, you only need to start the timer and can skip these first two lines
            circles.Add(rnd.Next(15) * 6 + 76);
            Invalidate();
            timer1.Start();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, 100, 100, 700, 100);
            for (int i = 0; i < circles.Count; i++)
            {
                e.Graphics.DrawEllipse(Pens.Red, 180 + (30 * i), circles[i], 8, 6);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (circles.Count < maxCircleCount)
            {
                circles.Add(rnd.Next(15) * 6 + 76);
                Invalidate();
            }
            else
            {
                timer1.Stop();
            }
        }
    }

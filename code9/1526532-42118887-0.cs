    public partial class Form1 : Form
    {
        private Timer _timer;
        private List<PointF> _points;
        public Form1()
        {
            InitializeComponent();
            _timer = new Timer(100);
            timer.Tick += OnTick;
            timer.Start();
        }
        private void OnTick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Aqua);
            e.Graphics.DrawRectangle(Pens.Black, 10, 10, 10, 10);
        }
    }

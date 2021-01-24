    public partial class Form1 : Form
    {
        const int velocity = 15;
        Point position_A = new Point(24, 16);
        Point position_B = new Point(24, 74);
        Size size_A = new Size(115, 50);
        Size size_B = new Size(115, 50);
        Size velocity_A = new Size(0, 0);
        Size velocity_B = new Size(0, 0);
        public Rectangle Shape_A
        {
            get
            {
                return new Rectangle(position_A, size_A);
            }
        }
        public Rectangle Shape_B
        {
            get
            {
                return new Rectangle(position_B, size_B);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, Shape_A);
            e.Graphics.FillRectangle(Brushes.Black, Shape_B);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.position_A+=velocity_A;
            this.position_B+=velocity_B;
            pictureBox1.Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"KeyDown Code:{e.KeyCode}");
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.velocity_A=new Size(velocity_A.Width, -velocity);
                    break;
                case Keys.Down:
                    this.velocity_A=new Size(velocity_A.Width, +velocity);
                    break;
                case Keys.Left:
                    this.velocity_A=new Size(-velocity, velocity_A.Height);
                    break;
                case Keys.Right:
                    this.velocity_A=new Size(+velocity, velocity_A.Height);
                    break;
                case Keys.W:
                    this.velocity_B=new Size(velocity_B.Width, -velocity);
                    break;
                case Keys.S:
                    this.velocity_B=new Size(velocity_B.Width, +velocity);
                    break;
                case Keys.A:
                    this.velocity_B=new Size(-velocity, velocity_B.Height);
                    break;
                case Keys.D:
                    this.velocity_B=new Size(+velocity, velocity_B.Height);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
            pictureBox1.Invalidate();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                    this.velocity_A=new Size(velocity_A.Width, 0);
                    break;
                case Keys.Right:
                case Keys.Left:
                    this.velocity_A=new Size(0, velocity_A.Height);
                    break;
                case Keys.W:
                case Keys.S:
                    this.velocity_B=new Size(velocity_B.Width, 0);
                    break;
                case Keys.A:
                case Keys.D:
                    this.velocity_B=new Size(0, velocity_B.Height);
                    break;
            }
        }
    }

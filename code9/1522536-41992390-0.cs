    public partial class Form1 : Form
    {
        const int step = 15;
        int x1 = 24;
        int y1 = 16;
        int size1 = 115;
        int size2 = 50;
        int x2 = 24;
        int y2 = 74;
        int size3 = 115;
        int size4 = 50;
        public Form1()
        {
            InitializeComponent();
        }
        public Rectangle A
        {
            get
            {
                return new Rectangle(x1, y1, size1, size2);
            }
        }
        public Rectangle B
        {
            get
            {
                return new Rectangle(x2, y2, size3, size4);
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, A);
            e.Graphics.FillRectangle(Brushes.Black, B);
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Right)
            {
                x1+=step;
            }
            if (e.KeyData==Keys.Left)
            {
                x1-=step;
            }
            if (e.KeyData==Keys.Up)
            {
                y1-=step;
            }
            if (e.KeyData==Keys.Down)
            {
                y1+=step;
            }
            if (e.KeyData==Keys.D)
            {
                x2+=step;
            }
            if (e.KeyData==Keys.A)
            {
                x2-=step;
            }
            if (e.KeyData==Keys.W)
            {
                y2-=step;
            }
            if (e.KeyData==Keys.S)
            {
                y2+=step;
            }
            pictureBox1.Invalidate();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }

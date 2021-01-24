    namespace dragAndDropRect
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Rectangle rect = new Rectangle(30, 30, 30, 30);
            g.FillRectangle(Brushes.Aqua, rect);
            if (e.Button == MouseButtons.Left)
            {
                Refresh();
                g.Invalidate();
                g.FillRectangle(Brushes.AliceBlue, e.X, e.Y, 30, 30);
            }
        }
    }
    }

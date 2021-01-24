    public partial class Form1 : Form
    {
        bool mousepressed;
        int x1=0, y1=0,x2=0,y2=0;
        Pen newPen = new Pen(Color.Blue, 2);
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousepressed = true;
            x1 = e.X;
            y1 = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousepressed)
            {
                x2 = e.X;
                y2 = e.Y;
                pictureBox1.Refresh();
            }            
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(newPen, x1, y1, x2, y2);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousepressed = false;
        }
    }

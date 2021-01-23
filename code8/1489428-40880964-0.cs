    public partial class Form1 : Form
    {
        Image signature;
        bool clicked = false;
        Point previousPoint;
        public Form1()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            this.MouseLeave += Form1_MouseLeave;
            this.FormClosing += Form1_FormClosing;
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Dispose signature after closing the form to avoid memory leak
            signature.Dispose();
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (signature != null)
                e.Graphics.DrawImage(signature, 0, 0);
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            previousPoint = e.Location;
        }
        void Form1_MouseLeave(object sender, EventArgs e)
        {
            clicked = false;
        }
        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                if (signature == null)
                    signature = new Bitmap(this.Width, this.Height);
                using (Graphics g = Graphics.FromImage(signature))
                {
                    g.DrawLine(Pens.Black, previousPoint, e.Location);
                    previousPoint = e.Location;
                    this.Invalidate();
                }
            }
        }
    }

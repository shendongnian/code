    public partial class Form1 : Form
    {
        private int spx, spy, length;
        private Pen pen = new Pen(new SolidBrush(Color.Red), 0.5f);
        private Point a,m;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh(); // force redraw
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            length = Math.Min(e.ClipRectangle.Height, e.ClipRectangle.Width) / 2;
            if (length != 0) // can't draw when there's no space
            {
                m = new Point(e.ClipRectangle.Width / 2, e.ClipRectangle.Height / 2);
                int seconde = DateTime.Now.Second;
                spx = m.X + (int)(length * Math.Sin(Math.PI * seconde / 30));
                spy = m.Y - (int)(length * Math.Cos(Math.PI * seconde / 30));
                a = new Point(spx, spy);
                e.Graphics.DrawLine(pen, m, a);
            }
        } 
    }

     public class PanelZ : System.Windows.Forms.Panel
     {
        public PanelZ()
        {
            Width = 200;
            Height = 200;
            DoubleBuffered = true;
            lines = 9;
        }
        public   int lines { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen mypen = new Pen(Brushes.Black, 1);
            Font myfont = new Font("tahoma", 10);
            float x = 0;
            float y = 0;
            float xSpace = Width / lines;
            float yspace = Height / lines;
            for (int i = 0; i < lines + 1; i++)
            {
                g.DrawLine(mypen, x, y, x, Height);
                x += xSpace;
            }
            for (int i = 0; i < lines + 1; i++)
            {
                g.DrawLine(mypen, 0, y, Width, y);
                y += yspace;
            }
        }
    }

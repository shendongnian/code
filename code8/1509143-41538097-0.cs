     public class PanelZ : System.Windows.Forms.Panel
     {
        public PanelZ()
        {
            Width = 200;
            Height = 200;
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen mypen = new Pen(Brushes.Black, 1);
            Font myfont = new Font("tahoma", 10);
            int lines = 9;
            float x = 0;
            float y = 0;
            float xSpace = Width / lines;
            float yspace = Height / lines;
            for (int i = 0; i < lines + 1; i++)
            {
                g.DrawLine(mypen, x, y, x, Height);
                x += xSpace;
            }
            x = 0f;
            for (int i = 0; i < lines + 1; i++)
            {
                g.DrawLine(mypen, x, y, Width, y);
                y += yspace;
            }
        }
    }

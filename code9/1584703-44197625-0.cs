    class draw
    {
        public static void circle(int x, int y, int width, int height, Graphics g)
        {
            Pen color = new Pen(Color.Red);
            System.Drawing.SolidBrush fillblack = new System.Drawing.SolidBrush(Color.Black);
            Rectangle circle = new Rectangle(x, y, width, height);
            g.DrawEllipse(color, circle);
        }
    }

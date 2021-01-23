    class Snake
    {
        public static int x = 20;
        public static int y = 20;
        public static int r = 20;
        public void Draw(Graphics G)
        {
            SolidBrush brush = new SolidBrush(Color.Green);
            G.FillRectangle(brush, x, y, r, r);
        }
    }
    //...
    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        using (Graphics G = panel1.CreateGraphics())
        {
            Snake s = new Snake();
            s.Draw(G);
        }
    }

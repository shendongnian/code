    class Snake : Form1
    {
        public static int x = 20;
        public static int y = 20;
        public static int r = 20;
        public void Draw()
        {
          panel1.Refresh() ;
        }
         private void panel1_Paint(object sender, PaintEventArgs e)
         {
            SolidBrush brush = new SolidBrush(Color.Green);
            Graphics G = panel1.CreateGraphics();
            G.FillRectangle(brush, x, y, r, r);
         }
}

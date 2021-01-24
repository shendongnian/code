    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Bitmap screen = new Bitmap(600, 800);
        Graphics gfx = Graphics.FromImage(screen);
        SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 0));
        gfx.FillRectangle(brush, 0, 0, 600, 800);
        e.Graphics.DrawImage(screen, 0, 0);
        gfx.Dispose();
        brush.Dispose();
        screen.Dispose();
    }

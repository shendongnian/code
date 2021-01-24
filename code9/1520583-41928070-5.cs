    float zoom = 1f;
    private void drawPanel1_Paint(object sender, PaintEventArgs e)
    {
        Point c = new Point(drawPanel1.ClientSize.Width / 2, drawPanel1.ClientSize.Height / 2);
        // a blue sanity check for testing
        e.Graphics.FillEllipse(Brushes.DodgerBlue, c.X - 3, c.Y - 3, 6, 6);
        // the offsets you were looking for:
        float ox = c.X * ( zoom - 1f);
        float oy = c.Y * ( zoom - 1f);
        // first move and then scale
        e.Graphics.TranslateTransform(-ox, -oy);
        e.Graphics.ScaleTransform(zoom, zoom);
         // now we can draw centered around our point c
        Size sz = new Size(300, 400);
        int count = 10;
        int wx = sz.Width  / count;
        int wy = sz.Height / count;
        for (int i = 0; i < count; i++)
        {
            Rectangle r = new Rectangle(c.X - i * wx / 2 , c.Y - i * wy / 2, i * wx, i * wy );
            e.Graphics.DrawRectangle(Pens.Red, r );
        }
    }

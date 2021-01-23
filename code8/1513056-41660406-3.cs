    Shape selected = null;
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (selected != null)
        {
            selected.FillColor = ((Bitmap)pictureBox1.Image).GetPixel(e.X, e.Y);
            Invalidate();
        }
    }
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        foreach(Shape gp in paths)
            if (gp.Path.IsVisible(e.Location))
                { selected = gp; break; }
    }

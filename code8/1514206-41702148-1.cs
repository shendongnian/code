    private void originalmaster_MouseClick(object sender, MouseEventArgs e)
    {
        Point mDown = Point.Round(stretched(e.Location, originalmaster));
        Color c = ((Bitmap)originalmaster.Image).GetPixel(mDown.X, mDown.Y);
        // do your stuff:
        BackColor = c;
    }

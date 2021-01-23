    static int ColorDelta(Color c1, Color c2)
    {
        return Math.Abs(c1.R - c2.R) + Math.Abs(c1.G - c2.G) - Math.Abs(c1.B - c2.B);
    }
    private void pictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        var color = _zoneMap.GetPixel(e.X, e.Y);
        if (90 > ColorDelta(color, Color.FromArgb(0, 0, 255)))
            MessageBox.Show("Zone 1");
        else if (90 > ColorDelta(color, Color.FromArgb(255, 0, 0)))
            MessageBox.Show("Zone 2");
        else if (90 > ColorDelta(color, Color.FromArgb(0, 255, 0)))
            MessageBox.Show("Zone 3");
        // etc...
    }

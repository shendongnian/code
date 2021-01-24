    Point mDown = Point.Empty;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        mDown = e.Location;
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button.HasFlag(MouseButtons.Left))
            pictureBox1.Left += e.X - mDown.X;
    }

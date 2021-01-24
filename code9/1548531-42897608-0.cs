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
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        Timer t = new Timer() { Interval = 15 };
        t.Tick += (ss, ee) =>
        {
            if (pictureBox1.Right < panel1.Width)
            {
                pictureBox1.Left += 1;
            }
            else t.Stop();
        };
        t.Start();
    }

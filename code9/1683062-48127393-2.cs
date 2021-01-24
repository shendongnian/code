    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        // vvv take care of automatic disposal 
        using (Graphics g = pictureBox1.CreateGraphics())
        using (Pen newpen = new Pen(Color.Blue, 1))
        {
            if (mousepress)
            {
                pictureBox1.Refresh(); // <-- get rid of the previous lines
                g.DrawLine(newpen, x1, y1, e.Location.X, e.Location.Y);
                x2 = e.Location.X;
                y2 = e.Location.Y;
                angle = GetAngle(x1, y1, x2, y2);
            }
            // Invalidate(); // check if necessary!
        }
    }

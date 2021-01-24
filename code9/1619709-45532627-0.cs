    private void pictureBox1_Click (object sender, EventArgs e)
    {
        Point ellipseCenter = ((MouseEventArgs) e).Location;
        Size  ellipseSize   = new Size (50, 50);
        Point rectPosition = new Point (ellipseCenter.X - ellipseSize.Width / 2, ellipseCenter.Y - ellipseSize.Height / 2);
        Rectangle rect = new Rectangle (rectPosition, ellipseSize);
        using (Graphics grp = Graphics.FromImage (pictureBox1.Image))
        {
            grp.DrawEllipse (Pens.Red, rect);
        }
        pictureBox1.Refresh ();
    }

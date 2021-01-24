    private void gridImage_MouseMove(object sender, MouseEventArgs e)
    {
        mousePosition = e.Location;
        pictureBox1.Invalidate();
    }

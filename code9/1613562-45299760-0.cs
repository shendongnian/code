    private void pictureBoxTgt_MouseClick(object sender, MouseEventArgs e)
    {
        Bitmap bmp = (Bitmap)pictureBoxTgt.Image;
        Color c0 = bmp.GetPixel(e.X, e.Y);
        Fill4(bmp, e.Location, c0, lbl_color.BackColor);
        pictureBoxTgt.Image = bmp;
    }

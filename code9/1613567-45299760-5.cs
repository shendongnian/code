    private void pictureBoxTgt_MouseClick(object sender, MouseEventArgs e)
    {
        Point sPt = scaledPoint(pictureBoxTgt, e.Location);
        Bitmap bmp = (Bitmap)pictureBoxTgt.Image;
        Color c0 = bmp.GetPixel(sPt.X, sPt.Y); 
        Fill4(bmp, sPt, c0, lbl_color.BackColor);
        pictureBoxTgt.Image = bmp;
    }

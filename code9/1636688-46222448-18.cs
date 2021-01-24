    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        using (Bitmap bmp = new Bitmap(canvas.ClientSize.Width, 
                                       canvas.ClientSize.Height, PixelFormat.Format32bppPArgb))
        {
            PaintToBitmap(bmp);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

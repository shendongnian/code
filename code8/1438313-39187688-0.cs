    public void TakePhoto()
    {
        Bitmap bm = new Bitmap(picEmployeeImage.Width, picEmployeeImage.Height);
        bm = (Bitmap)picEmployeeImage.Image;
        Bitmap bmp = new Bitmap(bm.Width, bm.Height);
        Graphics g = Graphics.FromImage(bmp);
        g.DrawImage(bm, 0, 0, bmp.Width, bmp.Height);
        bmp.Save(@"\Images\" + currentlySelectedId + ".bmp", ImageFormat.Bmp);
    }

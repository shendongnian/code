    private Mat GetMatFromSDImage(System.Drawing.Image image)
    {
        int stride = 0;
        Bitmap bmp = new Bitmap(image);
        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
        System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
        System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
        if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        {
            stride = bmp.Width * 4;
        }
        else
        {
            stride = bmp.Width * 3;
        }
        Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);
        bmp.UnlockBits(bmpData);
        return cvImage.Mat;
    }

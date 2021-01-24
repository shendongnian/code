    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    System.Drawing.Imaging.BitmapData bmpData =
        bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.Read,
        bmp.PixelFormat);
    // Get the address of the first line.
    IntPtr ptr2pass = bmpData.Scan0;

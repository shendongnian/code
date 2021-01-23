    System.Drawing.Imaging.BitmapData bmpData =
        bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
        bmp.PixelFormat);
    var pt = (byte*)bmpData.Scan0;
    // for loop
    var row = pt + (y * bmpData.Stride);
    var pixel = row + x * bpp; // bpp is a number of dimensions for the bitmap

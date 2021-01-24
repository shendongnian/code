        var pixelData = new byte[width*height*4];
        wicBitmap.CopyPixels(pixelData, width*4);
        var bmp = new System.Drawing.Bitmap(width, height);
        var bd = bmp.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
            System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        Marshal.Copy(pixelData, 0, bd.Scan0, pixelData.Length);
        bmp.UnlockBits(bd);

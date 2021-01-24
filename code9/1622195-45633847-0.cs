    unsafe
    {
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0,0, 256, 256),ImageLockMode.ReadWrite, bitmap.PixelFormat);
        for (int j = 0; j < bitmapData.Height; j++)
        {
            byte* row = (byte*)bitmapData.Scan0 + (j * bitmapData.Stride);
            for (int k = 0; k < bitmapData.Width * 3; k += 3)
            {
                if (row[k] <= TresholdFilter)
                {
                   row[k] = 0;
                   row[k + 1] = 0;
                   row[k + 2] = 0;
                }
                if (row[k] > 0)
                {
                   row[k] = 255;
                   row[k + 1] = 255;
                   row[k + 2] = 255;
                }
            }
        }
        bitmap.UnlockBits(bitmapData);
    }

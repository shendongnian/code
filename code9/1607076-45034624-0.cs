    unsafe static ushort MaxRed(Bitmap bm)
    {
        var bd = bm.LockBits(new Rectangle(Point.Empty, bm.Size), ImageLockMode.ReadOnly, PixelFormat.Format48bppRgb);
        ushort maxRed = 0;
        for (int y = 0; y < bm.Height; y++)
        {
            ushort* ptr = (ushort*)(bd.Scan0 + y * bd.Stride);
            for (int x = 0; x < bm.Width; x++)
            {
                ushort b = *ptr++;
                ushort g = *ptr++;
                ushort r = *ptr++;
                maxRed = Math.Max(maxRed, r);
            }
        }
        bm.UnlockBits(bd);
        return maxRed;
    }

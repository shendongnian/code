    Bitmap bmp = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
    ColorPalette cp = bmp.Palette;
    for (Int32 i = 0; i < 256; ++i)
        cp.Entries[i] = Color.FromArgb(255, i, i, i);
    bmp.Palette = cp;
    BitmapData data = bmp.LockBits((new Rectangle(0, 0, bmp.Width, bmp.Height)), ImageLockMode.WriteOnly, bmp.PixelFormat);
    Marshal.Copy(data.Scan0, I_bytes, 0, I_bytes.Length);
    bmp.UnlockBits(data);

    BitmapData bufferData = buffer.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
    for (int x = 0; x < width; x++)
      for (int y = 0; y < height; y++)
        bufferData.SetPixel(x, y, CELL_DEAD);
    buffer.UnlockBits(bufferData);
    //////////
    public static unsafe void SetPixel(BitmapData data, int x, int y, byte pixel)
    {
      *((byte*)data.Scan0 + y * data.Stride + x) = pixel;
    }

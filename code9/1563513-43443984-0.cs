    private static void DoWork(Bitmap bitmap)
    {
        var width = bitmap.Width;
        var height = bitmap.Height;
        var rectangle = new Rectangle(0, 0, width, height);
        var data = bitmap.LockBits(rectangle, ImageLockMode.ReadOnly, bitmap.PixelFormat);
        var bitsPerPixel = GetBitsPerPixel(bitmap.PixelFormat);
        var bytesPerPixel = (bitsPerPixel + 7) / 8;
        var stride = data.Stride;
        var length = stride * data.Height;
        var pixels = new byte[length];
        Marshal.Copy(data.Scan0, pixels, 0, length);
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            var offset = y * stride + x * bytesPerPixel;
            var value = 0;
            for (var i = 0; i < bytesPerPixel; i++)
                value |= pixels[offset + i] << i;
        }
        bitmap.UnlockBits(data);
    }
    private static int GetBitsPerPixel(PixelFormat format)
    {
        switch (format)
        {
            case PixelFormat.Format8bppIndexed:
                return 1;
            case PixelFormat.Format16bppRgb555:
                return 2;
            case PixelFormat.Format24bppRgb:
                return 24;
            case PixelFormat.Format32bppRgb:
                return 32;
            default: // TODO
                throw new NotSupportedException();
        }
    }

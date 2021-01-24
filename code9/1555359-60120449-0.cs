    public static void FastMakeTransparent(this Bitmap bitmap, Color color)
    {
        BitmapData bitmapData = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        unsafe
        {
            int* pixelPointer = (int*)bitmapData.Scan0;
            int bitmapHeight = bitmap.Height;
            int bitmapWidth = bitmap.Width;
            int colorInt = color.ToArgb();
            int transparentInt = Color.Transparent.ToArgb();
            for (int i = 0; i < bitmapHeight; ++i)
            {
                for (int j = 0; j < bitmapWidth; ++j)
                {
                    if (*pixelPointer == colorInt)
                        *pixelPointer = transparentInt;
                    ++pixelPointer;
                }
            }
        }
        bitmap.UnlockBits(bitmapData);
    }

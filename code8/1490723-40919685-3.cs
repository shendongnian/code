    WriteableBitmap bmp = new WriteableBitmap(img.Source as BitmapImage);
    bmp.Lock();
    unsafe
    {
        int width = bmp.PixelWidth;
        int height = bmp.PixelHeight;
        byte* ptr = (byte*)bmp.BackBuffer;
        int stride = bmp.BackBufferStride;
        int bpp = 4; // Assuming Bgra image format
        int hms;
        for (int y = 0; y < height; y++)
        {
            hms = y * stride;
            for (int x = 0; x < width; x++)
            {
                int idx = hms + (x * bpp);
                byte b = ptr[idx];
                byte g = ptr[idx + 1];
                byte r = ptr[idx + 2];
                byte a = ptr[idx + 3];
                // Construct your histogram
            }
        }
    }
    bmp.Unlock();

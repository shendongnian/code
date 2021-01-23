    public unsafe Color GetTextColor(Bitmap bitmap)
    {
        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        try
        {
            const int bytesPerPixel = 3;
            const int red = 2;
            const int green = 1;
            int halfHeight = bitmap.Height / 2;
            byte* row = (byte*)_bitmapData.Scan0 + (halfHeight * _bitmapData.Stride);
            Color startingColour = Color.FromArgb(row[red], row[green], row[0]);
            for (int wi = bytesPerPixel, wc = _bitmapData.Width * bytesPerPixel; wi < wc; wi += bytesPerPixel)
            {
                Color thisColour = Color.FromArgb(row[wi + red], row[wi + green], row[wi]);
                if (thisColour != startingColour)
                {
                    return thisColour;
                }
            }
            return Color.Empty; //Or some other default value
        }
        finally
        {
            bitmap.UnlockBits(bitmapData);
        }
    }

    public static unsafe void CopyBitmap(Bitmap from, Bitmap to, Rectangle destRect, Rectangle srcRect)
    {
        //Check rects line up appropriatley
        //You should get this and the PixelFormat's of the images properly
        //unless you can alsways assume the same format
        const int BYTES_PER_PIXEL = 4;
        BitmapData fromData = from.LockBits(new Rectangle(Point.Empty, from.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
        try
        {
            BitmapData toData = to.LockBits(new Rectangle(Point.Empty, to.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
            try
            {
                //For the purpose of this example I will assume that srcRect and destRect have the same width and height
                int xOffset = (destRect.X - srcRect.X) * BYTES_PER_PIXEL;
                int yOffset = destRect.Y - srcRect.Y;
                for (int hi = srcRect.Y, hc = srcRect.Bottom; hi < hc; ++hi)
                {
                    byte* fromRow = (byte*)fromData.Scan0 + (hi * fromData.Stride);
                    byte* toRow = (byte*)toData.Scan0 + ((hi + yOffset) * toData.Stride);
                    for (int wi = (srcRect.X * BYTES_PER_PIXEL), wc = (srcRect.Right * BYTES_PER_PIXEL);
                            wi < wc; wi += BYTES_PER_PIXEL)
                    {
                        //Adjust this if you have a different format
                        toRow[xOffset + wi] = fromRow[wi];
                        toRow[xOffset + wi + 1] = fromRow[wi + 1];
                        toRow[xOffset + wi + 2] = fromRow[wi + 2];
                        toRow[xOffset + wi + 3] = fromRow[wi + 3];
                    }
                }
            }
            finally
            {
                to.UnlockBits(fromData);
            }
        }
        finally
        {
            from.UnlockBits(fromData);
        }
    }

    BitmapData data = image.LockBits(new Rectangle(startX, startY, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat);
        try
        {
            byte[] pixelData = new Byte[data.Stride];
            for (int scanline = 0; scanline < data.Height; scanline++)
            {
                Marshal.Copy(data.Scan0 + (scanline * data.Stride), pixelData, 0, data.Stride);
                for (int pixeloffset = 0; pixeloffset < data.Width; pixeloffset++)
                {
                    // PixelFormat.Format32bppRgb means the data is stored
                    // in memory as BGR. We want RGB, so we must do some 
                    // bit-shuffling.
                    rgbArray[offset + (scanline * scansize) + pixeloffset] = 
                        (pixelData[pixeloffset * PixelWidth + 2] << 16) +   // R 
                        (pixelData[pixeloffset * PixelWidth + 1] << 8) +    // G
                        pixelData[pixeloffset * PixelWidth];                // B
                }
            }
        }
        finally
        {
            image.UnlockBits(data);
        }

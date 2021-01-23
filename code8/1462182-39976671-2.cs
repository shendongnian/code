    public static Bitmap ChangeColorBrightness(Bitmap bmp, float correctionFactor)
    {  
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
        byte[] rgbValues = new byte[bytes];
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); 
        float correctionFactortemp = correctionFactor;
        if (correctionFactor < 0)
        {
            correctionFactortemp = 1 + correctionFactor;
        }
        for (int counter = 1; counter < rgbValues.Length; counter ++)
        {
            float color = (float)rgbValues[counter];
            if (correctionFactor < 0)
            {
                color *= (int)correctionFactortemp;
            }
            else
            {
                color = (255 - color) * correctionFactor + color;                  
            }
            rgbValues[counter] = (byte)color;          
        }
        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
        bmp.UnlockBits(bmpData);
        return bmp;
    }

    using System.Runtime.InteropServices;
    using System.Drawing.Imaging;
    public bool testForYellowBitmap(Bitmap bmp)
    {
        Size s1 = bmp.Size;
        PixelFormat fmt = new PixelFormat();
        fmt = bmp.PixelFormat;
        Rectangle rect = new Rectangle(0, 0, s1.Width, s1.Height);
        BitmapData bmp1Data = bmp.LockBits(rect, ImageLockMode.ReadOnly, fmt);
        byte bpp1 = 4;
        if (fmt == PixelFormat.Format24bppRgb) bpp1 = 3;
        else if (fmt == PixelFormat.Format32bppArgb) bpp1 = 4; else return false; // throw!!
        int size1 = bmp1Data.Stride * bmp1Data.Height;
        byte[] data1 = new byte[size1];
        System.Runtime.InteropServices.Marshal.Copy(bmp1Data.Scan0, data1, 0, size1);
        for (int y = 0; y < s1.Height; y++)
        {
            for (int x = 0; x < s1.Width; x++)
            {
                Color c1;
                int index1 = y * bmp1Data.Stride + x * bpp1;
                if (bpp1 == 4)
                    c1 = Color.FromArgb(data1[index1 + 3], data1[index1 + 2],
                                        data1[index1 + 1], data1[index1 + 0]);
                else c1 = Color.FromArgb(255, data1[index1 + 2], 
                                              data1[index1 + 1], data1[index1 + 0]);
                if (c1.R > 220 && c1.G > 220 && c1.B < 200) return true; ;
            }
        }
        bmp.UnlockBits(bmp1Data);
        return false;
    }

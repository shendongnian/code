    using System.Runtime.InteropServices;
    ..
    public static void UnSemi(Bitmap bmp)
    {
        Size s = bmp.Size;
        PixelFormat fmt = bmp.PixelFormat;
        Rectangle rect = new Rectangle(Point.Empty, s);
        BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, fmt);
        int size1 = bmpData.Stride * bmpData.Height;
        byte[] data = new byte[size1];
        System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, size1);
        for (int y = 0; y < s.Height; y++)
        {
            for (int x = 0; x < s.Width; x++)
            {
                int index = y * bmpData.Stride + x * 4;
                data[index + 3] = (data[index + 3] < 255) ? (byte)0 : (byte)255;
            }
        }
        System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
    }

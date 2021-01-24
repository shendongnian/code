    void SetAlphaOverlay(Bitmap bmp, Color col)
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
                if (data[index + 0] + data[index + 1] + data[index + 2] > 0)
                {
                    data[index + 0] = col.B;
                    data[index + 1] = col.G;
                    data[index + 2] = col.R;
                    data[index + 3] = col.A;
                }
            }
        }
        System.Runtime.InteropServices.Marshal.Copy(data, 0, bmpData.Scan0, data.Length);
        bmp.UnlockBits(bmpData);
    }

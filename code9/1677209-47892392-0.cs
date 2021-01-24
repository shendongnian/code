    private System.Drawing.Bitmap ConvertBitmapSourceToDrawingBitmap(BitmapSource image)
    {
        int width = Convert.ToInt32(image.Width);
        int height = Convert.ToInt32(image.Height);
        int stride = Convert.ToInt32(width * ((image.Format.BitsPerPixel + 7) / 8) + 0.5);
        byte[] bits = new byte[height * stride];
        image.CopyPixels(bits, stride, 0);
        System.Drawing.Bitmap bitmap = null;
        unsafe
        {
            fixed (byte* pBits = bits)
            {
                IntPtr ptr = new IntPtr(pBits);
                bitmap = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ptr);
            }
        }
        return bitmap;
    }

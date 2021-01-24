            public static Mat ToMat(BitmapSource source)
            {
                if (source.Format == PixelFormats.Bgr32)
                {
                    Mat result = new Mat();
                    result.Create(source.PixelHeight, source.PixelWidth, DepthType.Cv8U, 4);
                    source.CopyPixels(Int32Rect.Empty, result.DataPointer, result.Step * result.Rows, result.Step);
                    return result;
                }
            }
    public static BitmapSource ToBitmapSource(IImage image)
    {
        using (System.Drawing.Bitmap source = image.Bitmap)
        {
            IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap
            BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                ptr,
                IntPtr.Zero,
                Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(ptr); //release the HBitmap
            return bs;
        }
    }

    public static void RotateAndSaveImage(string path, WriteableBitmap bitmap, double angle)
    {
        try
        {
            if (bitmap != null)
            {
                var tb = new TransformedBitmap((bitmap), new RotateTransform(angle));
                var src = tb as BitmapSource;
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(src));
                    encoder.Save(stream);
                }
            }
        } catch {}
    }

     List<Image> images = new List<Image>();
     Stream imageStreamSource = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
     TiffBitmapDecoder decoder = new TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.None, BitmapCacheOption.Default);
     foreach (BitmapSource bitmapSource in decoder.Frames)
     {
         Bitmap bmp = new Bitmap(bitmapSource.PixelWidth, bitmapSource.PixelHeight, PixelFormat.Format32bppPArgb);
         BitmapData data = bmp.LockBits(new Rectangle(System.Drawing.Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
         bitmapSource.CopyPixels(Int32Rect.Empty,  data.Scan0,  data.Height * data.Stride, data.Stride);
         bmp.UnlockBits(data);
         images.Add(bmp);
     }

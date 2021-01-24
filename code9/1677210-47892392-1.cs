        System.Windows.Media.Imaging.BitmapSource bitmapSource;
        using (System.IO.Stream stm = System.IO.File.Open("c:\\foo_in.png", System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            // Since we're not specifying a System.Windows.Media.Imaging.BitmapCacheOption, the pixel format
            // will be System.Windows.Media.PixelFormats.Pbgra32.
            bitmapSource = System.Windows.Media.Imaging.BitmapFrame.Create(
                stm,
                System.Windows.Media.Imaging.BitmapCreateOptions.None,
                System.Windows.Media.Imaging.BitmapCacheOption.OnLoad);
        }
        System.Drawing.Bitmap bmp = ConvertBitmapSourceToDrawingBitmap(bitmapSource);
        bmp.Save("c:\\foo_out.png", System.Drawing.Imaging.ImageFormat.Png);

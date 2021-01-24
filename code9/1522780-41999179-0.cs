    using (var ms = new MemoryStream())
    {
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        ms.Seek(0, SeekOrigin.Begin);
        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = ms;
        bitmapImage.EndInit();
        return bitmapImage;
    }

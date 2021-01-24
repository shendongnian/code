    var image = new BitmapImage();
    using (var stream = new FileStream(currentFile, FileMode.Open, FileAccess.Read))
    {
        image.BeginInit();
        image.DecodePixelWidth = 100;
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream;
        image.EndInit();
    }
    image.Freeze();
    CurrentImage.Source = image;

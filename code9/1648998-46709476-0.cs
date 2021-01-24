    var webClient = new WebClient();
    var buffer = webClient.DownloadData(url);
    var bitmapImage = new BitmapImage();
    using (var stream = new MemoryStream(buffer))
    {
        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();
    }
    bitmapImage.Freeze();

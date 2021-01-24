    public static BitmapSource GetNewImage(Uri uri)
    {
        var webClient = new WebClient();
        var buffer = webClient.DownloadData(uri);
        using (var stream = new MemoryStream(buffer))
        {
            return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }

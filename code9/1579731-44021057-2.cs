    public ImageSource Image
    {
        get
        {
            var buffer = new WebClient().DownloadData(url);
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(
                    stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }

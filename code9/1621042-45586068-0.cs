    Stream streamObject = GetStreamFromUrl(filePath);
    DocX doc = DocX.Load(streamObject);
    
    private static Stream GetStreamFromUrl(string url)
    {
        byte[] imageData = null;
        using (var wc = new WebClient())
        {
            imageData = wc.DownloadData(url);
        }
        return new MemoryStream(imageData);
    }

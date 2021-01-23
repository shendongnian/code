    using (var client = new WebClient())
    {
        var content = client.DownloadData(url);
        using (var stream = new MemoryStream(content))
        {
            ...
        }
    } 

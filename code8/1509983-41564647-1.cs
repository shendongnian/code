    private async Task DownloadFile()
    {
        if (_downloadUrls.Any())
        {
            WebClient client = new WebClient();
            [...]
            sw = Stopwatch.StartNew();
            await client.DownloadFileTaskAsync(new Uri(url), @"C:\Temp\TestingSatelliteImagesDownload\" + count + ".jpg");
            return;
        }
    }

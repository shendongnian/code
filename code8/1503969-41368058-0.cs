                foreach (string url in ExtractImages.imagesUrls)
                {
    
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), @"C:\Temp\TestingSatelliteImagesDownload\" + count + ".jpg");
                }

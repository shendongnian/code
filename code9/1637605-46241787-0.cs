    public static Task DownloadFile(string url)
    {
        using (var client = new WebClient())
        {
            client.DownloadProgressChanged += (o, e) =>
            {
                lock (client)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write(e.ProgressPercentage + "%");
                }
            };
            return client.DownloadFileTaskAsync(new Uri(url), @"c:\asd");
        }
    }

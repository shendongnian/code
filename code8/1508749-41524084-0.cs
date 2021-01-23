    int currentRequest = 1;
    Object lockObject = new Object();
    for (int i = 0; i < requests.Count; i++) {
        using (var webclient = new WebClient())
        {
            webclient.DownloadStringCompleted += (sender, e) =>
            {
                lock(lockObject) 
                {
                   Console.WriteLine();
                   ...                
                   currentRequest += 1;
                }
            };
            webclient.DownloadStringAsync(new Uri("URL HERE"));
        }
    }

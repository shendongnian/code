    using (var client = new WebClient())
    {
        string response = client.DownloadString(path);
        if (!string.IsNullOrEmpty(response))
        {
           ...
        }
    }

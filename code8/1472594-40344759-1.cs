    public string Get()
    {
      using (var client = new WebClient())
        return client.DownloadString(...);
    }

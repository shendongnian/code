    private void DownloadInformation(string id)
    {
        using (WebClient wc = new WebClient())
        {
            string response = await wc.DownloadStringTaskAsync(new Uri("http://www.fake.com/" + id));
            // TODO: Process response
        }
    }

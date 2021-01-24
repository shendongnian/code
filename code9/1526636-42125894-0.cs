    public async Task DownloadIt(string url ,string filename)
    {
         using (var client = new WebClient())
         {
             await client.DownloadFileTaskAsync(new Uri(url), filename);
         }
    }

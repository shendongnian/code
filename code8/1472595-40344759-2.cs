    private async Task<string> GetCoreAsync(bool sync)
    {
      using (var client = new WebClient())
      {
        return sync ?
            client.DownloadString(...) :
            await client.DownloadStringTaskAsync(...);
      }
    }
    public string Get() => GetCoreAsync(sync: true).GetAwaiter().GetResult();
    public Task<string> GetAsync() => GetCoreAsync(sync: false);

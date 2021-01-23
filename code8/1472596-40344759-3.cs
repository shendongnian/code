    private string GetCoreSync()
    {
      using (var client = new WebClient())
        return client.DownloadString(...);
    }
    private static HttpClient HttpClient { get; } = ...;
    private async Task<string> GetCoreAsync(bool sync)
    {
      return sync ?
          GetCoreSync() :
          await HttpClient.GetString(...);
    }
    public string Get() => GetCoreAsync(sync: true).GetAwaiter().GetResult();
    public Task<string> GetAsync() => GetCoreAsync(sync: false);

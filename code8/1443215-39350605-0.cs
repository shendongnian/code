    private static HttpClient client = new HttpClient();
    private static async Task DownloadAndProcessAsync(string value)
    {
      var response = await client.GetStringAsync($"http://api.com/?value={value}");
      // Process response.
    }

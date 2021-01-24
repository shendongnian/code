    var tasks = Enumerable.Range(1, 1000).Select(i => TryGetStringAsync("https://somewebsite.com/" + i));
    var responseStrings = await Task.WhenAll(tasks);
    var validResponses = responseStrings.Where(x => x != null);
    private async Task TryGetStringAsync(string url)
    {
      try
      {
        return await httpClient.GetStringAsync(url);
      }
      catch (HttpRequestException)
      {
        return null;
      }
    }

    static void Main(string[] args)
    {
      WebClient w = new WebClient();
      Console.WriteLine(Environment.CurrentManagedThreadId);
      Task<string> resultFromWebClient = GetAsync(w);
      Console.WriteLine($"result = {resultFromWebClient.Result}");
      Console.ReadKey();
    }
    static async Task<string> GetAsync(WebClient w)
    {
      Console.WriteLine(Environment.CurrentManagedThreadId);
      return await w.DownloadStringTaskAsync("http://www.omdbapi.com/?s=batman");
    }

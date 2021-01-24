    public static class SchedulerHttpClient
    {
      private static Lazy<Task<HttpClient>> _Client = new Lazy<Task<HttpClient>>(async () =>
      {
        var client = new HttpClient();
        await MainAsync(client).ConfigureAwait(false);
        return client;
      });
      public static Task<HttpClient> ClientTask => _Client.Value;
      private static async Task MainAsync(HttpClient client) { ... }
      private static async Task<string> AcquireTokenBySPN(HttpClient client, string tenantId, string clientId, string clientSecret) { ... }
      private static async Task<dynamic> HttpPost(HttpClient client, string tenantId, string payload) { ... }
    }

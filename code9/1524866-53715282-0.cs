    public interface ISomeApiClient
    {
        Task<HttpResponseMessage> GetSomethingAsync(string query);
    }
    public class SomeApiClient : ISomeApiClient
    {
        private readonly HttpClient _client;
        public SomeApiClient (HttpClient client)
        {
            _client = client;
        }
        public async Task<SomeModel> GetSomethingAsync(string query)
        {
            var response = await _client.GetAsync($"?querystring={query}");
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsJsonAsync<SomeModel>();
                return model;
            }
            // Handle Error
        }
    }

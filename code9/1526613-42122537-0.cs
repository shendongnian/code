    static HttpClient _client = new HttpClient(); // you should reuse a HttpClient!
    
    private async Task<string> FetchStuffAsync()
    {
        using (var response = await _client.GetAsync("http://google.com"))
        {
            if (response.IsSuccessStatusCode)
            {
                // Horray it went well!
                var page = await response.Content.GetStringAsync();
                return page;
            }
        }
    
        return null;
    }

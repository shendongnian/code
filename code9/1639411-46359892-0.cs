    var httpClientHandler = new HttpClientHandler
    {
        AllowAutoRedirect = false,
        ....
    };
    var httpClient = new System.Net.Http.HttpClient(httpClientHandler)
    {
        MaxResponseContentBufferSize = 5000000,
        ...
    };
    
    var uri = new Uri("http://x.com");
    using (var response = await httpClient.GetAsync(uri))
    {
      if (!response.IsSuccessStatusCode)
           throw new HttpRequestException($"URL {uri} not loaded. {response.StatusCode}");
    
        var str = await response.Content.ReadAsStringAsync();
        // ...
    }

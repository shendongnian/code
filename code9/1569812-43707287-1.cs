    TestServer _owinTestServer;
    public async Task<HttpResponse message> Method1(string url, object body) {
        return await _owinTestServer.HttpClient.PostAsJsonAsync(url, body);
    }
    
    public async Task<ItemPreview> Method2(object body) {
        var response = await Method1("..", body );
        return await response.Content.ReadAsAsync<ItemPreview>();
    }

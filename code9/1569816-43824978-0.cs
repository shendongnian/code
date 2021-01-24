    TestServer _owinTestServer;
    public async Task<HttpResponse message> Method1(string url, object body)
    {
        return await _owinTestServer.HttpClient.PostAsJsonAsync(url,body);
    }
    public async Task<ItemPreview> Method2(object body);
    {
         return await Method1("..", body ).Result.Content.ReadAsAsync<ItemPreview>();
    }
    [TestMethod]
    public void test1()
    {
        Item item = new(...);
        await Method2(item).ContinueWith(task => {// Never reach     here }
    }

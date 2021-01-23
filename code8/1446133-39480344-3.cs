    public async Task<HttpResponseMessage> GetHttpResponse()
    {
        using (var client = GetHttpClient())
        {
            return await TaskEx.Run(() => client.SendAsync(new HttpRequestMessage()));

    public async Task<HttpResponseMessage> GetHttpResponse()
    {
        using (var client = GetHttpClient(twitterQuery, handler))
        {
            return await TaskEx.Run(() => client.SendAsync(new HttpRequestMessage()));
        }
    }

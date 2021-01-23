    public HttpResponseMessage GetHttpResponse()
    {
        using (var client = GetHttpClient(twitterQuery, handler))
        {
            return TaskEx.Run(() => client.SendAsync(new HttpRequestMessage())).Result;
        }
    }

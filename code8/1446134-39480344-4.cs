    public HttpResponseMessage GetHttpResponse()
    {
        using (var client = GetHttpClient())
        {
            return TaskEx.Run(() => client.SendAsync(new HttpRequestMessage())).Result;
        }
    }

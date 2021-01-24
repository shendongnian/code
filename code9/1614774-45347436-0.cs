    private static Task<HttpResponseMessage> AwaitResponse(HttpRequest proxy) {
        foreach (var header in proxy.Request.Headers) {
            Client.Instance.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
        return Client.Instance.SendAsync(proxy.Request);
    }

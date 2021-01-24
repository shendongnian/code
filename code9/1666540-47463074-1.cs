    public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent httpContent)
    {
        // TODO add some error handling
        var method = new HttpMethod("PATCH");
        var request = new HttpRequestMessage(method, requestUri) {
            Content = httpContent
        };
        return await client.SendRequestAsync(request);
    }

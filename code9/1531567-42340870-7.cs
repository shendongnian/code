    public override async Task<HttpResponseMessage> ReceiveAsync(
        string id, HttpRequestContext context, HttpRequestMessage request)
    {
        ...
        if (request.Method == HttpMethod.Post)
        {
            // here is what you don't want to be called
            // you want ReadAsJsonAsync(), In short, USE A DIFFERENT RECEIVER.
            NameValueCollection data = await ReadAsFormDataAsync(request);
            ...
        }
        else
        {
           return CreateBadMethodResponse(request);
        }
    }

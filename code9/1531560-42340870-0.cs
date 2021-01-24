    public override async Task<HttpResponseMessage> ReceiveAsync(
        string id, HttpRequestContext context, HttpRequestMessage request)
    {
        ...
        if (request.Method == HttpMethod.Post)
        {
            // here is what you don't want to be called
            // you want ReadAsJsonAsync()
            // so, don't use this reciever for JSON
            NameValueCollection data = await ReadAsFormDataAsync(request);
            ...
        }
        else
        {
           return CreateBadMethodResponse(request);
        }
    }

    private HttpResponseMessage Process(string receiver, HttpRequestMessage request)
    {
        return ProcessAsync(receiver, request).Result;
    }
    
    private async Task<HttpResponseMessage> ProcessAsync(string receiver, HttpRequestMessage request)
    {
        Reciever test = new Reciever();
        var  res = await test.ReceiveAsync(receiver, request);
        return res;
    }

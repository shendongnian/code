    ILog Log {get; set;}
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken token)
    {
        var requestTime = DateTime.Now;
        this.requestMessage = requestMessage;
        responseMessage = await base.SendAsync(requestMessage, token);
        var responseTime = DateTime.Now;
        log.Info(requestTime, responseTime); // No async needed
        return responseMessage;
    }

    [FunctionName("messages")]
    public static async Task Run([HttpTrigger(WebHookType = "genericJson")]
        HttpRequestMessage req)
    {
        // return from this Azure Function immediately to avoid timeout warning message 
        // in the chat.
        using (var client = new HttpClient())
        {
            string secret = ConfigurationManager.AppSettings["processMessageHttp_secret"];
            // change the RequestUri of the request to processMessageHttp Function's 
            // public URL, providing the secret code, stored in app settings 
            // with key 'processMessageHttp_secret'
            req.RequestUri = new Uri(req.RequestUri.AbsoluteUri.Replace(
                req.RequestUri.PathAndQuery, $"/api/processMessageHttp?code={secret}"));
            // don't 'await' here. Simply send.
    #pragma warning disable CS4014
            client.SendAsync(req);
    #pragma warning restore CS4014
            // wait a little bit to ensure the request is sent. It will not 
            // send the request at all without this line, because it would 
            // terminate this Azure Function immediately
            await Task.Delay(500);
        }
    }
    [FunctionName("processMessageHttp")]
    public static async Task ProcessMessageHttp([HttpTrigger(WebHookType = "genericJson")]
        HttpRequestMessage req,
        Microsoft.Extensions.Logging.ILogger log)
    {
        // first and foremost: initialize dependency 
        // injection container, logger, services, set default culture/language, etc.
        var initializer = FunctionAppInitializer.Initialize(log);
        // handle the request in a usual way and reply back to the chat
        await initializer.HandleRequest(req);
    }

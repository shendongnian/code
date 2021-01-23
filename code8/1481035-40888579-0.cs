     // configure method
    public IApplicationBuilder Configure(IApplicationBuilder app)
    {
        var ipService = app.ApplicationServices.GetService<IIpSetService>();
        MessageHandlerFactory.IIpSetService = ipService;
    }
    // static class
    public static IIpSetService IpSetService;
    public static IMessageProcessor Create(string messageType)
    {
        // use IpSetService
    }
    
    
    

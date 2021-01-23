    //Startup.cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
    
    public IApplicationBuilder Configure(IApplicationBuilder app)
    {
        var httpContextAccessor= app.ApplicationServices.GetService<IHttpContextAccessor>();
        MessageHandlerFactory.HttpContextAccessor = httpContextAccessor;
    }
    // static class
    public static IHttpContextAccessor HttpContextAccessor;
    public static IMessageProcessor Create(string messageType)
    {
        var ipSetService = HttpContextAccessor.HttpContext.RequestServices.GetService<IIpSetService>();
        // use it
    }
    
    

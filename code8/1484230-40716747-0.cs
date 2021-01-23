    public void ConfigureServices(IServiceCollection services)
    {
        //...
        services.AddTransient<IEmailSender, AuthMessageSender>();
        //...
        var provider = services.BuildServiceProvider();
        var emailSender= provider.GetService<IEmailSender>();
        // use emailSender
    }

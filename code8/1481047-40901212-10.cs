    public void ConfigureServices(IServiceCollection services)
    {            
        // ...
        // Add RabbitMQ services
        services.Configure<RabbitOptions>(Configuration.GetSection("rabbit"));
        services.AddTransient<MessageListener>();
        services.AddTransient<MessageHandlerFactory>();
        services.AddTransient<IpSetMessageProcessor>();
        services.AddTransient<EndpointMessageProcessor>();
    }

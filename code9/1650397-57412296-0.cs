    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHealthChecks()
                .AddRabbitmq("amqp://username:password@host:port/vhost"]);
    }

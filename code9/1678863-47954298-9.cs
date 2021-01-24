    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IApplicationLifetime applicationLifetime)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
        {
            var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
            {
                h.Username("guest");
                h.Password("guest");
            });
            sbc.ReceiveEndpoint(host, Configuration["QueueName"], e =>
            {
                e.LoadFrom(serviceProvider);
            });
        });
        // start/stop the bus with the web application
        applicationLifetime.ApplicationStarted.Register(bus.Start);
        applicationLifetime.ApplicationStopped.Register(bus.Stop);
    }

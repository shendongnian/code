    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        Bus.Factory.CreateUsingRabbitMq(sbc =>
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
        }
    }

    Func<IConsumeContext<MyMessage>, TightCoupleProcess> factory = c => new TightCoupleProcess(c);
    var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    
        cfg.ReceiveEndpoint(host, "customer_update_queue", e =>
        {
            e.Consumer<MyMessageConsumer>(() => new MyMessageConsumer(factory));
        });
    });

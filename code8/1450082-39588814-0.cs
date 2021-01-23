    var bus = Bus.Factory.CreateUsingRabbitMq(config =>
    {
      var host = config.Host(new Uri("rabbitmq://localhost/"), h => { });
      config.ReceiveEndpoint(host, "MTExQueue_" + Guid.NewGuid().ToString(), e => e.Consumer<SomethingHappenedConsumer>());
    });
    
    var busHandle = bus.Start();
    Console.ReadKey();
    busHandle.Stop();

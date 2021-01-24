    static async Task MainSubscribeAsync()
    {
        var connection = "amqp://jhgj67546:yjyj5565@localhost";
        using (var activator = new BuiltinHandlerActivator())
        {
            activator.Register(() => new WagonHandler());
            var bus = Configure.With(activator)
                .Logging(l => l.ColoredConsole())
                .Transport(t => t.UseRabbitMq(connection, "wagon_v1")
                    .ExchangeNames(directExchangeName: "WamosExchange"))
                .Start();
            await activator.Bus.Subscribe<Wagon>();
            Console.WriteLine("Done");
        }
    }

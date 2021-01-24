    static void Main(string[] args)
    {
        var channelFactory = new DefaultWampChannelFactory();
        var channel = channelFactory.CreateJsonChannel("wss://api.poloniex.com", "realm1");
    
        Func<Task> connect = async () =>
        {
            await Task.Delay(30000);
            await channel.Open();
    
            var tickerSubject = channel.RealmProxy.Services.GetSubject("ticker");
    
            var subscription = tickerSubject.Subscribe(evt =>
            {
                var currencyPair = evt.Arguments[0].Deserialize<string>();
                var last = evt.Arguments[1].Deserialize<decimal>();
                Console.WriteLine($"Currencypair: {currencyPair}, Last: {last}");
            },
            ex => {
                Console.WriteLine($"Oh no! {ex}");
            });
        };
    
        WampChannelReconnector reconnector =
            new WampChannelReconnector(channel, connect);
    
        reconnector.Start();
    
        Console.WriteLine("Press a key to exit");
        Console.ReadKey();
    }

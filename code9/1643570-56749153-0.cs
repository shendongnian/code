                using (var exitEvent = new ManualResetEvent(false))
                {
                    Console.CancelKeyPress += (sender, eventArgs) =>
                    {
                        eventArgs.Cancel = true;
                        exitEvent.Set();
                    };
   
                    ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
                    IDatabase db = redis.GetDatabase();
                    ISubscriber sub = redis.GetSubscriber();
                    sub.Subscribe("test", (channel, message) => {
                        Console.WriteLine("Got notification: " + (string)message);
                    });
    
                    Console.WriteLine("waiting...");
                    exitEvent.WaitOne();
                }

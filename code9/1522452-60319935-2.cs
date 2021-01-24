    static async Task Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50021", ChannelCredentials.Insecure);
            var client = new MapRouteClient(channel);
            int la = 1;
            int lo = 2;
            var reply = await client.GpsAsync(new MapPB.Location { La = la , Lo = lo });
            Console.WriteLine(reply.Name);
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

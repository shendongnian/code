    static void Main(string[] args)
    {
        var program = new Program();
        program.Test().Wait(); // Need to wait here
    }
    async Task Test()
    {
        Channel channel = new Channel($"127.0.0.1:50051", ChannelCredentials.Insecure);
        var client = new SplitTextClient(channel);
        using (var response = client.Split(new Text { Text_ = "a;b;c;d;e" }))
        {
            await Task.Delay(1000);
            while (await response.ResponseStream.MoveNext())
            {
                Console.WriteLine(response.ResponseStream.Current);
            }
        }
        Console.ReadLine();
    }

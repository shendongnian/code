    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        private static async Task RunAsync()
        {
            var channel = new Channel("127.0.0.1", 5000, ChannelCredentials.Insecure);
            var invoker = new DefaultCallInvoker(channel);
            using (var call = invoker.AsyncDuplexStreamingCall(Descriptors.Method, null, new CallOptions{}))
            {
                var responseCompleted = call.ResponseStream
                    .ForEachAsync(async response => 
                    {
                        Console.WriteLine($"Output: {response.Output}");
                    });
                
                await call.RequestStream.WriteAsync(new AdditionRequest { X = 1, Y = 2});
                Console.ReadLine();
                await call.RequestStream.CompleteAsync();
                await responseCompleted;
            }
            Console.WriteLine("Press enter to stop...");
            Console.ReadLine();
            await channel.ShutdownAsync();
        }
    }

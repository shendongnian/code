    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            var task = Task.Run(async delegate {
                Console.WriteLine("Before delay");
                await Task.Delay(1000);
                Console.WriteLine("After delay");
            });
            await task;
            Console.WriteLine("await");
            Console.ReadLine();
        }
    }

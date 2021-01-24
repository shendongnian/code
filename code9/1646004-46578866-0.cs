        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        private async static Task MainAsync(string[] args)
        {
            Console.WriteLine("Hello World!");
            await Task.WhenAll(MethodA(), MethodB1());
            await MethodB2();
        }
        private async static Task MethodA()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("A");
                // more code is running here (30 min)
            });
        }
        private async static Task MethodB1()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("B1");
                // more code is running here (2 min)
            });
        }
        private async static Task MethodB2()
        {
            await Task.Run(() =>
            {
                 Console.WriteLine("B2");
            });
        }

        public static async Task MainAsync(string[] args)
        {
            var instance = new SomeClass();
            var task = instance.Execute();
            Console.WriteLine("thread 1 waiting...");
            var secondTask = Task.Run(async () =>
            {
                Console.WriteLine("thread 2 started... waiting...");
                await task;
                Console.WriteLine("thread 2 ended!!!!!");
            });
            await task;
            await secondTask;
            Console.WriteLine("thread 1 done!!");
            Console.ReadKey();
        }

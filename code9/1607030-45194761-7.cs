        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to run.");
            Example thing = new Example();
            while (Console.ReadKey() != null)
                thing.Send();
        }
        class Example
        {
            Task<DisposableThing> DoTask()
            {
                return Task.Run(() => { Console.WriteLine("DoTask()"); return new DisposableThing(); });
            }
            Task<DisposableThing> DoTaskWillNotWork()
            {
                return new Task<DisposableThing>(() => { Console.WriteLine("DoTaskWillNotWork()"); return new DisposableThing(); });
            }
            async Task<DisposableThing> DoAsync()
            {
                Func<DisposableThing> action = new Func<DisposableThing>(() =>
                {
                    Console.WriteLine("DoAsync()");
                    return new DisposableThing();
                });
                return await Task.Run(action);
            }
            public Task Send()
            {
                return Task.Run(() =>
                {
                    using (DisposableThing client = new DisposableThing())
                    {
                        using (DisposableThing message = DoAsync().Result)
                        {
                            DisposableThing resultAsString = DoTask().Result;
                            DisposableThing resultAsString2 = DoTaskWillNotWork().Result;
                        }
                    }
                });
            }
        }
        class DisposableThing : IDisposable
        {
            public void Dispose()
            {
                //not much to do
            }
        }

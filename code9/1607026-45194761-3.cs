        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to run.");
            Example thing = new Example();
            while (Console.ReadKey() != null)
                thing.Send();
        }
        public class Example
        {
            Task DoTask()
            {
                return Task.Run(() => { Debug.WriteLine("DoTask()"); });
            }
            async Task<DisposableThing> DoAsync()
            {
                Func<DisposableThing> action = new Func<DisposableThing>(() =>
                {
                    Debug.WriteLine("DoAsync()");
                    return new DisposableThing();
                });
                return await Task.Run(action);
            }
            class DisposableThing : IDisposable
            {
                public void Dispose()
                {
                    //not much to do
                }
            }
            public Task Send()
            {
                return Task.Run(() =>
                {
                    using (DisposableThing client = new DisposableThing())
                    {
                        using (DisposableThing message = DoAsync().Result)
                        {
                            DisposableThing resultAsString = DoAsync().Result;
                        }
                    }
                });
            }
        }

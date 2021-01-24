    SemaphoreSlim _semaphore;
    static void Main(string[] args)
        {
            _semaphore = new SemaphoreSlim(0);
    
            Task.Factory.StartNew(() =>
            {
                while (true) //change to some parameter (for not infinity loop)
                {
                    doSomething();
                }
               _semaphore.Release();
            });
    
            _semaphore.Wait();
            Console.WriteLine("Task Paused");
            //.....
    
            Console.Read();
        }

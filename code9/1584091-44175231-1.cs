    SemaphoreSlim _semaphore;
    static void Main(string[] args)
        {
            _semaphore = new SemaphoreSlim(0);
    
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    _semaphore.Wait();
                    doSomething();
                }
              
            });
    
            _semaphore.Release();
            Console.WriteLine("Task Paused");
            Console.WriteLine("Task Will Resume After 1 Second");
            Thread.Sleep(1000);//To simulate, waiting data from Web Api etc.  for doSomething();    
             _semaphore.Release();
            Console.Read();
        }

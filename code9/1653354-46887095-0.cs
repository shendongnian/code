    static void Main(string[] args)
    {
    Stopwatch stopwatch = Stopwatch.StartNew();
    
    ManualResetEventSlim eventSlim = new ManualResetEventSlim(false);
    
    Task.Run(() =>
    {
        Task.Run(() =>
        {
            Thread.Sleep(1000);
    
            eventSlim.Set();
        });
    
        eventSlim.Wait();
    
        Console.WriteLine($"Hello from the Task! {stopwatch.Elapsed}");
    });
    
    eventSlim.Wait();
    
    Console.WriteLine($"Hello from the Main thread! {stopwatch.Elapsed}");
    
    stopwatch.Stop();
    
    //Console.ReadLine();
    }

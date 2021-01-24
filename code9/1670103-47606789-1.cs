    static async Task DoWork()
    {
        var worker = new Worker();
        await worker.StartWork(1, 2000);
        await worker.StartWork(2, 0);
        await worker.StartWork(3, 1500);
    }
    static void Main(string[] args)
    {
        DoWork().Wait();
        Console.WriteLine("Done.");
    }  

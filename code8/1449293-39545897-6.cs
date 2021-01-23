    static async Task GetAsync()
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Iterate GetAsync: {i}");
            await Task.Delay(500);
        }
    }
    static Task GetSomethingAsync() => GetAsync();
    static void Main(string[] args)
    {
        Task gettingSomethingTask = GetSomethingAsync();
        
        Console.WriteLine("GetAsync Task returned");
        Console.WriteLine("Start sleeping");            
        Thread.Sleep(3000);            
        Console.WriteLine("End sleeping");
        Console.WriteLine("Before Task awaiting");
        gettingSomethingTask.Wait();
        Console.WriteLine("After Task awaited");
        Console.ReadLine();
    }

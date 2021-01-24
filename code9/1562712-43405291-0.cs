    public static void Main(string[] args)
    {
        // You have to put a synchronous Wait() here because
        // Main cannot be declared as async
        new Program().Start().Wait();
    }
    public async Task Start()
    {
        int num1 = await GetNumber();
        int num2 = await GetNumber();
        int num3 = await GetNumber();
        Console.WriteLine("Wait...");
        Console.ReadKey();
    }
    public static async Task<int> GetNumber()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(4000));
        Console.WriteLine("Hello");
        return 0;
    }

    public static void Main()
    {
        Console.WriteLine("Press any key to print 'Hello, world!' after 2 seconds");
        while(true)
        {
            Console.ReadKey();
            KeyPressed();
        }
    }
    // WARNING: "async void" is discouraged!
    private static async void KeyPressed()
    {
        await Task.Delay(2000);
        Console.WriteLine(string.Format("Hello world! (from thread {0})", Thread.CurrentThread.ManagedThreadId);
    }

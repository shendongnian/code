    public static async Task DelayAndThenPrint(int mills)
    {
        return await Task.Run(async () =>
        {
            await Task.Delay(mills);
            Console.WriteLine(string.Format("Delayed {0} milliseconds and then reached here", mills));                          
        });
    }
    public static void Main()
    {
        Task.Run(async () =>
        { 
            await DelayAndThenPrint(200);
            Console.WriteLine("hey!");
            await DelayAndThenPrint(100);
        }).Wait();  
    }

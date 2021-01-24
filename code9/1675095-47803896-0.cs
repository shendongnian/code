    public async Task MyWaitMethod() 
    {
        await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
        {
            Console.WriteLine("Start");
            await Task.Delay(5000);
            Console.WriteLine("Done");
        });
        Console.WriteLine("All done");
    }

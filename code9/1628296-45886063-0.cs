    void Main()
    {
        Task.WaitAll(FirstRequest(), SecondRequest());
    }
    
    // Define other methods and classes here
    private async static Task FirstRequest()
    {
        // Do your work for one of the WebRequests here
        await Task.Delay(3000);
        Console.WriteLine("Done with 1");
    }
    
    private async static Task SecondRequest()
    {
        // Do your work for the second WebRequest here
        await Task.Delay(3000);
        Console.WriteLine("Done with 2");
    }

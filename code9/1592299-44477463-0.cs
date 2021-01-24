    static void Main(string[] args)
    {
        // Attempt at a DNS attack
        Task.Run(async () =>
        {
            for(;;;)
            {
                HttpWebResponse resp = await DoSomethingAsync();
                PrintResponseToConsole(resp); // <---------- THIS LINE
                await Task.Delay(50);
            }
        });
    }

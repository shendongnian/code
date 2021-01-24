    while (true)
    {
        string item = Console.ReadLine();
        Task.Run(() =>
        {
            Console.WriteLine($"Started reading {item}...");
            Thread.Sleep(1000); //simulate intense work
            Console.WriteLine($"Done reading {item}");
        });
    }

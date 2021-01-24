    BlockingCollection<string> collection = new BlockingCollection<string>(new ConcurrentQueue<string>());
    Task t = Task.Run(() =>
    {
        while (collection.TryTake(out string item, Timeout.Infinite))
        {
            Console.WriteLine($"Started reading {item}...");
            Thread.Sleep(1000); //simulate intense work
            Console.WriteLine($"Done reading {item}");
        }
    });
    while (true)
    {
        //This could be your OnReceivingFeedMessage()
        string input = Console.ReadLine();
        if (input == "stop")
        {
            Console.WriteLine("Stopping...");
            collection.CompleteAdding();
            break;
        }
        else
        {
            collection.Add(input);
        }
    }
    t.Wait();

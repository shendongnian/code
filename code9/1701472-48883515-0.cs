    var blockingCollection = new BlockingCollection<int>();
    // this is a single, one and only producer thread
    Task.Run(() =>
    {
        var number = 0;
        while (true)
        {
            number++;
            Console.WriteLine("tx --> " + number);
            blockingCollection.Add(number);
            Task.Delay(1000).Wait();
        }
    });
    // single, one and only consumer thread
    foreach (var item in blockingCollection.GetConsumingEnumerable())
    {
        Task.Delay(200).Wait();
        Console.WriteLine("    " + item + " --> rx");
    }

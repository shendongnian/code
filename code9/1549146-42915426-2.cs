    static void Main()
    {
        const int maxItemsToTake = 1000;
        // Populate array with 5841 items of data
        var lotsOfItems = new List<int>();
        for (int i = 0; i < 5841; i++)
        {
            lotsOfItems.Add(i);
        }
        int indexOfLastItemTaken = 0;
        while (indexOfLastItemTaken < lotsOfItems.Count - 1)
        {
            var itemsTaken = lotsOfItems.Skip(indexOfLastItemTaken).Take(maxItemsToTake);
            ProcessItems(itemsTaken);
            indexOfLastItemTaken += itemsTaken.Count();
        }
        Console.Write("Done. Press any key to quit...");
        Console.ReadKey();
    }
    static void ProcessItems(IEnumerable<int> input)
    {
        // do something with input
        Console.WriteLine(new string('-', 15));
        Console.WriteLine($"Processing a new batch of {input.Count()} items:");
        Console.WriteLine(string.Join(",", input));
    }

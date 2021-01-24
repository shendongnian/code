    static void Main()
    {
        int indexOfLastTakenItem = 0;
        int maxItemsToTake = 1000;
        var lotsOfItems = new List<int>();
        // Populate array with 5841 items of data
        for (int i = 1; i < 5841; i++)
        {
            lotsOfItems.Add(i);
        }
        while (indexOfLastTakenItem < lotsOfItems.Count - 1)
        {
            var itemsTaken = lotsOfItems.Skip(indexOfLastTakenItem).Take(maxItemsToTake);
            ProcessItems(itemsTaken);
            indexOfLastTakenItem += itemsTaken.Count();
        }
        Console.ReadLine();
    }
    static void ProcessItems(IEnumerable<int> input)
    {
        // do something with input
        Console.WriteLine(input.Count());
    }

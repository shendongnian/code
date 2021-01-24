    var bc = BlockingCollection<string>();
    SlowOutput(bc);
    foreach(var line in bc.GetConsumingEnumerable()) //Blocks till a item is added to the collection. Leaves the foreach loop after CompleteAdding() is called and there are no more items to be processed.
    {
        Console.WriteLine(line)
    }

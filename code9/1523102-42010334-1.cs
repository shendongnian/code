    public BlockingCollection<Item> queue = new BlockingCollection<Item>();
    public void LoadItems()
    {
        var(var item in SomeDataSource())
        {
             queue.Add(item);
        }
        queue.CompleteAdding();
    }
    
    public void ConsumeItems()
    {
        foreach(var item in queue.GetConsumingEnumerable())
        {
             ...
        }
    }

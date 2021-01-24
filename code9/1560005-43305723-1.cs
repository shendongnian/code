    public static void Main(string[] args)
    {
        var workQueue = new WorkQueue();
        workQueue.StartProducingItems();
        workQueue.StartProcessingItems();
        Console.WriteLine("Press a key to terminate the application...");
        Console.ReadLine();
    }

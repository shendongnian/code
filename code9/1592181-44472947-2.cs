    public static void Run(string input, CloudQueue outputQueue)
    {
        outputQueue.AddMessage(
            new CloudQueueMessage("Hello " + input),
            TimeSpan.FromMinutes(5));
    }

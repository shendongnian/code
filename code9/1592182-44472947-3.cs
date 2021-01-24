    public static void Run(string input, IBinder binder)
    {
        string outputQueueName = "outputqueue " + input;
        QueueAttribute queueAttribute = new QueueAttribute(outputQueueName);
        CloudQueue outputQueue = binder.Bind<CloudQueue>(queueAttribute);
        outputQueue.AddMessage(
            new CloudQueueMessage("Hello " + input),
            TimeSpan.FromMinutes(5));
    }

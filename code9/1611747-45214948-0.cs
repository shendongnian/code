    public static void Run(TimerInfo myTimer, TraceWriter log, ICollector<string> outputSbQueue)
    {
        string message = $"Service Bus queue message created at: {DateTime.Now}";
        log.Info(message); 
        outputSbQueue.Add("1 " + message);
        outputSbQueue.Add("2 " + message);
    }

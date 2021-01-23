    public static void CreateQueueMessage([ServiceBusTrigger("servicebusqueuename")] string message, [Queue("azurestoragequeuename")] out string outputQueueMessage, TextWriter log)
    {
        var text = message.ToUpper();
        outputQueueMessage = text;
        log.WriteLine(message);
    }

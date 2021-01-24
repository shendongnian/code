    public static void ProcessQueueMessage([QueueTrigger("myqueue")] string message, ExecutionContext context, TextWriter log)
    {
        log.WriteLine(message);
        SaveStatusToTableStorage(context.InvocationId, "Fail/Success");
    }

    [FunctionName("TimerTriggerCSharp")]
    public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer,
                           TraceWriter log,
                           [ServiceBus("%QueueName%", Connection = "ServiceBusConnection", EntityType = Microsoft.Azure.WebJobs.ServiceBus.EntityType.Queue)] out string msg)
    {
       msg = "My message";
    }

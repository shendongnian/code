    [FunctionName("ServiceBusOutput")]
    [return: ServiceBus("myqueue", Connection = "ServiceBusConnection")]
    public static string ServiceBusOutput([HttpTrigger] dynamic input, TraceWriter log)
    {
        log.Info($"C# function processed: {input.Text}");
        return input.Text;
    }

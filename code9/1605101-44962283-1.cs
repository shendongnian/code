    [FunctionName("SomeEventProcessor")]
    [return: Queue("myQueueName", Connection = "myconnection")]
    public static EventInfo Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")]HttpRequestMessage req,
        TraceWriter log)
    {
        log.Info("C# HTTP trigger function processed a request.");
        EventInfo eventInfo = new EventInfo(); //Just a container
        eventInfo.SomeID = req.Headers.Contains("SomeID") ? req.Headers.GetValues("SomeID").First() : null;
        return eventInfo;
    }

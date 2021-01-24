    public static class SomeEventProcessor
    {
        [FunctionName("SomeEventProcessor")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")]HttpRequestMessage req,
            TraceWriter log,
            [Queue("myQueueName", Connection = "myconnection")] IAsyncCollector<EventInfo> outputQueue)
        {
            log.Info("C# HTTP trigger function processed a request.");
            EventInfo eventInfo = new EventInfo(); //Just a container
            eventInfo.SomeID = req.Headers.Contains("SomeID") ? req.Headers.GetValues("SomeID").First() : null;
            //Write to a queue and promptly return
            await outputQueue.AddAsync(eventInfo);
            return req.CreateResponse(HttpStatusCode.OK);
        }
    }

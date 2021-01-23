    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.ServiceBus;
    using System;
    using Newtonsoft.Json;
    using Microsoft.Extensions.Logging;
    namespace Experimental.Functions
    {
        public static class ListenToEventFunction
        {
            [FunctionName("ListenToEventFunction")]
            public static void Run([EventHubTrigger("events", Connection = "EventHubConnectionString")]string myEventHubMessage, ILogger log)
            {
                log.LogInformation($"C# Event Hub trigger function processed a message: {myEventHubMessage}");
            }
        }
    }

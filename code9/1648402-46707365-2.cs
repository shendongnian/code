    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Azure.WebJobs.ServiceBus; // INCLUDE THIS FOR EVENT HUB ATTRIBUTE
    namespace FunctionApp1
    {
        public static class Function1
        {
            [FunctionName("QueueTriggerCSharp")]        
            public static async Task Run([QueueTrigger("myqueue-items", Connection = "QueueStorageConnectionString")]string myQueueItem, [Table("tableName", Connection = "StorageAccountConnectionString")]CloudTable inputTable, [EventHub("eventHubName", Connection = "EventHubConnectionString")]IAsyncCollector<string> outputEventHubMessages, TraceWriter log)
            {
                log.Info($"C# Queue trigger function processed: {myQueueItem}");
                
                TableQuery<TableEntity> query = new TableQuery<FailedEventEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "helloWorld"));
                List<TableEntity> entities = inputTable.ExecuteQuery(query).ToList();
                await _outputEventHubMessages.AddAsync(myQueueItem);
            }
        }
    } 

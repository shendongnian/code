    private const int BatchSize = 100;
    
    private static async void ConfigureAzureStorageTable()
    {
        CloudStorageAccount storageAccount =
            CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        TableResult result = new TableResult();
        CloudTable table = tableClient.GetTableReference("test");
        table.CreateIfNotExists();
    
        var batchOperation = new TableBatchOperation();
    
        for (int i = 0; i < 10000; i++)
        {
            var verifyVariableEntityObject = new VerifyVariableEntity()
            {
                ConsumerId = String.Format("{0}", i),
                Score = String.Format("{0}", i * 2 + 2),
                PartitionKey = String.Format("{0}", i),
                RowKey = String.Format("{0}", i * 2 + 2)
            };
            TableOperation insertOperation = TableOperation.Insert(verifyVariableEntityObject);
            batchOperation.Add(insertOperation);
    
            if (batchOperation.Count >= BatchSize)
            {
                try
                {
                    await table.ExecuteBatchAsync(batchOperation);
                    batchOperation = new TableBatchOperation();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    
        if(batchOperation.Count > 0)
        {
            try
            {
                await table.ExecuteBatchAsync(batchOperation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            TableResult result = new TableResult();
            CloudTable table = tableClient.GetTableReference("test");
            table.CreateIfNotExists();
            //Generate records to be inserted into Azure Table Storage
            var entities = Enumerable.Range(1, 10000).Select(i => new VerifyVariableEntity()
            {
                ConsumerId = String.Format("{0}", i),
                Score = String.Format("{0}", i * 2 + 2),
                PartitionKey = String.Format("{0}", i),
                RowKey = String.Format("{0}", i * 2 + 2)
            });
            //Group records by PartitionKey and prepare for executing batch operations
            var batches = TableBatchHelper<VerifyVariableEntity>.GetBatches(entities);
            //Execute batch operations in parallel
            Parallel.ForEach(batches, new ParallelOptions()
            {
                MaxDegreeOfParallelism = 5
            }, (batchOperation) =>
            {
                try
                {
                    table.ExecuteBatch(batchOperation);
                    Console.WriteLine("Writing {0} records", batchOperation.Count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ExecuteBatch throw a exception:" + ex.Message);
                }
            });
            Console.WriteLine("Done!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

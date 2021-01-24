    var storage = CloudStorageAccount
                .Parse(ConfigurationManager.AppSettings["AzureStorageConnectionString"]);
    CloudTableClient tableClient = storage.CreateCloudTableClient();
    string tableName = Constants.AzureLogTableName;
    CloudTable table = tableClient.GetTableReference(tableName);
    TableQuery<LogEntity> query = new TableQuery<LogEntity>();
    // Print the fields for each customer.
    foreach (LogEntity entity in table.ExecuteQuery(query))
    {
        Console.WriteLine("{0}, {1}\t{2}\t{3}\t{4}", entity.PartitionKey, entity.RowKey,
            entity.MessageTemplate, entity.Level, entity.RenderedMessage);
    }

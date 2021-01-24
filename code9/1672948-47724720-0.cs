    // Retrieve the storage account from the connection string.
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        CloudConfigurationManager.GetSetting("StorageConnectionString"));
    // Create the table client.
    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    // Create the CloudTable object that represents the "asometrichub" table.
    CloudTable table = tableClient.GetTableReference("customer");
    string combinedFilter = TableQuery.CombineFilters(
        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "section3"),
        TableOperators.And,
        TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, DateTime.UtcNow.AddHours(-12)));
    combinedFilter = TableQuery.CombineFilters(
        combinedFilter,
        TableOperators.And,
        TableQuery.GenerateFilterCondition("FirstName", QueryComparisons.Equal, "value3"));
    TableQuery rangeQuery = new TableQuery().Where(combinedFilter);

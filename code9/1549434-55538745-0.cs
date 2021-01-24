    private static async Task ProcessMessage(string message, DateTime enqueuedTime)
    {
        var deviceData = JsonConvert.DeserializeObject<JObject>(message);
        var dynamicTableEntity = new DynamicTableEntity();
        dynamicTableEntity.RowKey = enqueuedTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        foreach (KeyValuePair<string, JToken> keyValuePair in deviceData)
        {
            if (keyValuePair.Key.Equals("MyPartitionKey"))
            {
                dynamicTableEntity.PartitionKey = keyValuePair.Value.ToString();
            }
            else if (keyValuePair.Key.Equals("Timestamp")) // if you are using a parameter "Timestamp" it has to be stored in a column named differently because the column "Timestamp" will automatically be filled when adding a line to table storage
            {
                dynamicTableEntity.Properties.Add("MyTimestamp", EntityProperty.CreateEntityPropertyFromObject(keyValuePair.Value));
            }
            else
            {
                dynamicTableEntity.Properties.Add(keyValuePair.Key, EntityProperty.CreateEntityPropertyFromObject(keyValuePair.Value));
            }
        }
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse("myStorageConnectionString");
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        CloudTable table = tableClient.GetTableReference("myTableName"); 
        table.CreateIfNotExists();
        var tableOperation = TableOperation.Insert(dynamicTableEntity);
        await table.ExecuteAsync(tableOperation);
    }

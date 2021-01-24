        static void SaveDataInTable(int jobId, XDocument details)
        {
            var cred = new StorageCredentials(accountName, accountKey);
            var account = new CloudStorageAccount(cred, true);
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("MyTable");
            table.CreateIfNotExists();
            var entity = new DynamicTableEntity(partitionKey: "PK", rowKey: "RK");
            entity.Properties.Add("jobId", new EntityProperty(jobId));
            entity.Properties.Add("details", new EntityProperty(details.ToString()));//Convert XML to string
            var insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }

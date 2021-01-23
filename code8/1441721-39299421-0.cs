        static void QueryProjectionExample()
        {
            var cred = CloudStorageAccount.DevelopmentStorageAccount;
            var client = cred.CreateCloudTableClient();
            var table = client.GetTableReference("TableName");
            var query = new TableQuery<DynamicTableEntity>()
            {
                SelectColumns = new List<string>()
                {
                    "RowKey", "Version"
                }
            };
            var queryOutput = table.ExecuteQuerySegmented<DynamicTableEntity>(query, null);
            var results = queryOutput.Results;
            foreach (var entity in results)
            {
                Console.WriteLine("RowKey = " + entity.RowKey + "; Version = " + entity.Properties["Version"].StringValue);
            }
        }

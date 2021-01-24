            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                 "yourstorageaccount");
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("tablename");
            string filter = TableQuery.GenerateFilterCondition(
        "PartitionKey", QueryComparisons.Equal, "Aut");
            TableContinuationToken continuationToken = null;
            TableQuery<BookTest3> query = new TableQuery<BookTest3>().Where(filter);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var queryResult = table.ExecuteQuerySegmented(query, continuationToken).Results;
            watch.Stop();
            //get the execute time
            float seconds = watch.ElapsedMilliseconds/ 1000;
           //Serialize the object
           string s = JsonConvert.SerializeObject(queryResult);
           //get bytes
            float re =   System.Text.Encoding.Unicode.GetByteCount(s)/1000;
            Console.WriteLine(re/seconds);
            Console.Read();

            //initiate the writer
            var sw = new StreamWriter(@"C:\ProgramData\N3RASupportNotifier\Test.csv"); 
            var writer = new CsvWriter(sw);
                TableQuery<IssueEntity> query = new TableQuery<IssueEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Issues"));
            //Write each record to CSV
                foreach (IssueEntity entity in table.ExecuteQuery(query))
                {
                writer.WriteField(entity.FirstName);
                writer.WriteField(entity.LastName);
                writer.WriteField(entity.Location);
                writer.WriteField(entity.Manager);
                writer.WriteField(entity.PartitionKey);
                writer.WriteField(entity.PhoneSystem);
                writer.WriteField(entity.PrimaryIssue);
                writer.WriteField(entity.Timestamp);
                writer.NextRecord();
                }

    using (SqlTransaction transaction = myConnection.BeginTransaction())
    {
        using (var bulkCopy = new SqlBulkCopy(myConnection, SqlBulkCopyOptions.Default, transaction))
        {
           try
           {
                bulkCopy.DestinationTableName = Constants.DestinationTableName;
                bulkCopy.ColumnMappings.Add("JobId", "JobId");
                bulkCopy.ColumnMappings.Add("DateTime", "DateTime");
                bulkCopy.WriteToServer(dataSource);
                transaction.Commit();
           }
           catch (Exception ex)
           {
               Logger.Error(ex.Message, "Error while inserting data");
               transaction.Rollback();
           }
        }
    }

        private void BulkCopy(SqlConnection sqlConnection,string tableName, DataTable dataTable)
        {
			using (var bulkCopy = new SqlBulkCopy(sqlConnection))
			{
				bulkCopy.DestinationTableName = tableName;
				bulkCopy.BatchSize = 50000;
				bulkCopy.BulkCopyTimeout = 60; //seconds
				bulkCopy.WriteToServer(dataTable);
			}
        }

    private void BulkSaveCsvData(DataTable dt, string destinationTableName)
        {
            using (var bulkCopy = new SqlBulkCopy(_dbConnecion, SqlBulkCopyOptions.Default))
            {
                foreach (DataColumn col in dt.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = destinationTableName;
                bulkCopy.WriteToServer(dt);
            }
        }

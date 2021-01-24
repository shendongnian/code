    public static void BulkInsertDataTable(string connectionString, string tableName, DataTable table)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );
    
                    bulkCopy.DestinationTableName = tableName;
                    connection.Open();
    
                    bulkCopy.WriteToServer(table);
                    connection.Close();
                }
            }

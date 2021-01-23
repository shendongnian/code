     public bool isCopyInProgess = false;//not necessary - just part of my code
        public  void saveDataTable(string tableName, DataTable table)
        {
            using (SqlConnection conn = getConn())
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn))//, SqlBulkCopyOptions.KeepIdentity))//un-comment if you want to use your own identity column
                {
                    // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                    foreach (DataColumn col in table.Columns)
                    {
                        //Console.WriteLine("mapping " + col.ColumnName+" ("+does_Column_Exist(col.ColumnName,"Item").ToString()+")");
                        bulkCopy.ColumnMappings.Add(col.ColumnName, "["+col.ColumnName+"]");
                       // Console.WriteLine("ok\n");
                    }
                    bulkCopy.BulkCopyTimeout = 8000;
                    bulkCopy.DestinationTableName = tableName;
                    bulkCopy.BatchSize = 10000;
                    bulkCopy.EnableStreaming = true;
                    //bulkCopy.SqlRowsCopied += BulkCopy_SqlRowsCopied;
                    //bulkCopy.NotifyAfter = 10000;
                    isCopyInProgess = true;
                   bulkCopy.WriteToServer(table);
                }
                conn.Close();
            }
        }

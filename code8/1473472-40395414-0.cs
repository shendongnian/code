    using (var command = new SqlCommand(strCommandSql, remoteConn))
                {
                    command.CommandTimeout = 0;
                    using (var dataReader = command.ExecuteReader())
                    {
                        using (var bulkCopy = new SqlBulkCopy(this.LocalConnStr, SqlBulkCopyOptions.TableLock  | SqlBulkCopyOptions.UseInternalTransaction))
                        {
                            bulkCopy.DestinationTableName = this.TableName;
                            bulkCopy.BulkCopyTimeout = 0;
                            bulkCopy.WriteToServer(dataReader);
                            bulkCopy.Close();
                        }
                    }
                }

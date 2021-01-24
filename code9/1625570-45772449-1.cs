     public static  void BulInsert()
        {
            var destination = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = SampleDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; "; // your comnnection string
            var filename = @"d:\db.csv";//your source file
            var connString = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=No;FMT=Delimited""", Path.GetDirectoryName(filename));
            string query = string.Format("Select * from [{0}]", Path.GetFileName(filename));
            using (var conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand(query, conn);
                var reader = command.ExecuteReader();
                using (SqlConnection destConnection = new SqlConnection(destination))
                {
                    try
                    {
                        destConnection.Open();
                        using (SqlBulkCopy bulkCopy =
                          new SqlBulkCopy(destConnection))
                        {
                            // what ever mapping with ordinal
                            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(0, "Id"));
                            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, "name"));
                            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, "visit"));
                            bulkCopy.DestinationTableName =
                                "dbo.Patients";
                            try
                            {
                                bulkCopy.WriteToServer(reader);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            
        }

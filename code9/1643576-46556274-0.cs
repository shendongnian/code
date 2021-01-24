    public static void WriteToServer(string qualifiedTableName, DataTable dataTable)
                {
                    //**************************************************************************************************************************
                    //  Summary:  Hit the Oracle DB with the provided datatable. bulk insert data to table.
                    //**************************************************************************************************************************
                    //  History:
                    //   10/03/2017                 Created
                    //**************************************************************************************************************************
    
                    try
                    {
                        OracleConnection oracleConnection = new OracleConnection(Variables.strOracleCS);
    
                        oracleConnection.Open();
                        using (OracleBulkCopy bulkCopy = new OracleBulkCopy(oracleConnection))
                        {
                            bulkCopy.DestinationTableName = qualifiedTableName;
                            bulkCopy.WriteToServer(dataTable);
                        }
                        oracleConnection.Close();
                        oracleConnection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Utility.db.Log.Write(Utility.db.Log.Level.Error, "Utility", "db:WriteToServer: " + ex.Message);
                        throw;
                    }
                }

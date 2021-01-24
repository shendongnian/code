     public static DataTable ExecuteQuery(string storeProcedure, SqlParameter[] parameters)
            {
                    using (SqlConnection sqlConnection = new SqlConnection(DLLConfig.GetDataBaseConnection()))
                    {
                        DataTable dataTable = new DataTable();
                        SqlCommand sqlCommand = new SqlCommand(storeProcedure, sqlConnection);
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        foreach (SqlParameter param in parameters)
                        {
                            sqlCommand.Parameters.Add(param);
                        }
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
                        sqlAdapter.Fill(dataTable);
                        SqlConnection.ClearAllPools();
                        return dataTable;
                    }
    
            }

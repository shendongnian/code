    public DataTable dataTable(string procedureName, Dictionary<string, object> parameterList)
        {
            DataTable outputDataTable;
            using (MySqlConnection connection = new MySqlConnection("Server=localhost;" +
                                            "Port = 1234" +
                                            "Database=heatco;" +
                                            "Uid=root;" +
                                            "Pwd=123456;")
            {
                connection.Open();
                {
                    using (MySqlCommand SqlCommand = new MySqlCommand(procedureName, connection))
                    {
                        SqlCommand.CommandType = CommandType.StoredProcedure;
                    if (parameterList != null)
                    {
                        foreach (string key in parameterList.Keys)
                        {
                            string parameterName = key;
                            object parameterValue = parameterList[key];
                            sqlCommand.Parameters.Add(new MySqlParameter("intMaxCFM", 10000));
                            sqlCommand.Parameters.Add(new MySqlParameter("intMinCFM", 2223));
                            sqlCommand.Parameters.Add(new MySqlParameter("intMinMbh", 300));
                            sqlCommand.Parameters.Add(new MySqlParameter("dblDimA", 20000));
                            sqlCommand.Parameters.Add(new MySqlParameter("dblDimB", 20000));
                            sqlCommand.Parameters.Add(new MySqlParameter("dblDimC", 20000));
                            sqlCommand.Parameters.Add(new MySqlParameter("dblDimD", 20000));
                            MySqlCommand cm = new MySqlCommand("CALL sp_criteria()", MySqlConnection);
                        }
                    }
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                        DataSet outputDataSet = new DataSet();
                        sqlDataAdapter.Fill(outputDataSet, "compatibleset");
                        outputDataTable = outputDataSet.Tables["compatibleset"];
                    }
                }
            }
            return outputDataTable;
        }

            public DataTable getData(string procedureName, SqlParameter[] procedureParams)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                if (procedureParams != null)
                {
                    for (int i = 0; i < procedureParams.Length; i++)
                    {
                        command.Parameters.Add(procedureParams[i]);
                    }
                }
    
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds); //Fill DataSet and try accessing your table from DataSet
                return ds.Tables[0];
            }

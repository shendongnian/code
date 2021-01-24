    public static DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters)
    {
        using (SqlConnection sqlConnection = new SqlConnection(DLLConfig.GetDataBaseConnection()))
        {
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
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

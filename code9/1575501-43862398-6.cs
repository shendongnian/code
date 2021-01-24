    public static DataTable GetDataByStoredProcedure(string spName, List<SqlParameter> pars = null)
    {
        using(SqlConnection sqlConnection = new SqlConnection(connectionString))
        using(SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection))
        {
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if(pars != null) sqlCommand.Parameters.AddRange(pars.ToArray());
            using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
            {
                var dt = new DataTable("Command");
                dt.Load(dataReader);
                return dt;
             }
        }
    }

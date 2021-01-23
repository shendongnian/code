	public Task<SqlDataReader> GetSqlDataReader1(int recordCount)
    {
        var sqlCon = new SqlConnection(ConnectionString);
		sqlCon.Open();
		
		using (var command = new SqlCommand("sp_GetData", sqlCon))
		{
			command.Parameters.Clear();
			command.Parameters.Add(new SqlParameter("@recordCount", recordCount));
			command.CommandType = System.Data.CommandType.StoredProcedure;
			return command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
		}
    }

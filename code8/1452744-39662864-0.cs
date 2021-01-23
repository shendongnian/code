    public async Task<List<T>> GetData1(int recordCount)
    {
        using (var sqlCon = new SqlConnection(ConnectionString))
        {
            sqlCon.Open();
            using (var command = new SqlCommand("sp_GetData", sqlCon))
            {
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@recordCount", recordCount));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var result = new List<T>();
                var reader = await command.ExecuteReaderAsync();
                // TODO: use `reader` to populate `result`
                return result;
            }
        }
    }

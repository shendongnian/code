    public async Task<IEnumerable<IDataRecord>> GetSqlDataReader1(int recordCount)
    {
        using (var sqlCon = new SqlConnection(ConnectionString))
        {
            sqlCon.Open();
            using (var command = new SqlCommand("sp_GetData", sqlCon))
            {
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@recordCount", recordCount));
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                var rdr = await command.ExecuteReader();
                while (rdr.Read())
                {
                     yield return rdr;
                }
            }
        }
    }

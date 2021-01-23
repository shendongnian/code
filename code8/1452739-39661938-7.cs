    public async Task<IEnumerable<SomeObject>> GetSqlDataReader1(int recordCount)
    {
        using (var sqlCon = new SqlConnection(ConnectionString))
        using (var command = new SqlCommand("sp_GetData", sqlCon))
        {
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@recordCount", recordCount));
            command.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCon.Open();                
            var rdr = await command.ExecuteReaderAsync();
            while (rdr.Read())
            {
                 yield return new SomeObject() {Field1 = rdr[1], Field2 = rdr[2], etc};
            }
        }
    }

    // change return type to Task<int>
    public async Task<int> Iobound(SqlConnection conn, SqlTransaction tran) 
    {
        // this stored procedure takes a few seconds to complete
        using (SqlCommand cmd = new SqlCommand("MyIoboundStoredProc", conn, tran)) 
        {
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter returnValue = cmd.Parameters.Add("ReturnValue", SqlDbType.Int);
            returnValue.Direction = ParameterDirection.ReturnValue;
            // use async IO method and await it
            await cmd.ExecuteNonQueryAsync();
            return (int) returnValue.Value;
        }
    }

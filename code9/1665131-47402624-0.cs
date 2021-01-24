    private void StoreLocation(string locationId)
    {
        using (Conn)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[sp_EXAMPLESPROC]",Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter LocationParam = cmd.Parameters.AddWithValue("@LocationID", locationId);
            LocationParam.SqlDbType = SqlDbType.Structured;
            cmd.ExecuteNonQuery(); // Or however your sproc works.
        }
    }

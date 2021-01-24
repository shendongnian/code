    using (SqlConnection con = new SqlConnection(cs))
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        // cmd.CommandType = CommandType.StoredProcedure;
        ... 
        using(SqlDataReader rdr = cmd.ExecuteReader())
        {
            ....
        }
    }

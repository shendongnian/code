    using (SqlConnection con = new SqlConnection(_context.Database.Connection.ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("sp_InsertTerms", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerTermsTableType", SqlDbType.Structured).Value = Terms;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

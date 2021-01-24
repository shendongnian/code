    int recID = 0;
    string connStr = ProcThatGivesYouConnectionString();
    using (SqlConnection con = new SqlConnection(connStr))
    {
        con.Open();
        SqlCommand command = new SqlCommand("CREATE_RECORD", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Application", escalation.Application);
        command.Parameters.AddWithValue("@UpdatedTime", escalation.UpdatedTime);
        command.ExecuteNonQuery();
    }
    
    using (SqlConnection con2 = new SqlConnection(connStr))
    {
        con2.Open();
        SqlCommand command = new SqlCommand("Select @@Identity", con2);
        recID = (int)command.ExecuteScalar();
    }

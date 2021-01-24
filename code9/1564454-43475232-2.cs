    int recID = 0;
    string connStr = ProcThatGivesYouConnectionString();
    using (SqlConnection con = new SqlConnection(connStr))
    {
        con.Open();
        SqlCommand command = new SqlCommand("
    EXEC CREATE_RECORD @Application = @Application, @UpdatedTime = @UpdatedTime
    SELECT @@Identity", con);
        command.Parameters.AddWithValue("@Application", escalation.Application);
        command.Parameters.AddWithValue("@UpdatedTime", escalation.UpdatedTime);
        recID = (int)command.ExecuteScalar();
    }

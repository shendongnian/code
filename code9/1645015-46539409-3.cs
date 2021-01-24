    using(SqlConnection con = new SqlConnection(connectionstring))
    {
        SqlCommand command = new SqlCommand("spEmptask",con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@taskTable", dt(your DataTable)));
    }

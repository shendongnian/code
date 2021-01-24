    using (SqlConnection connection = new SqlConnection(connectionString))
        {
        
        connection.Open();
        SqlCommand command = new SqlCommand("UpdateEmployeeTable", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@EmployeeID", 123));
        command.CommandTimeout = 5;
        command.ExecuteNonQuery();
        connection.close();
    }

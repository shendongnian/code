    try 
    {
        SqlConnection connection = new SqlConnection(DBHelper.ConnectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("Some Simple Insert Query", connection);
        command.ExecuteNonQuery();
    } finally 
    {
        command.Dispose();
        connection.Close();
        connection.Dispose();
    }

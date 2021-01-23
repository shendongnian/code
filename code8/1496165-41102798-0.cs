    public void InsertData()
    {
        SqlConnection connection = new SqlConnection(DBHelper.ConnectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("Some Simple Insert Query", connection);
        command.ExecuteNonQuery(); // <- imagine that this throws exception 
        // and so these don't execute at all and you have to resources leaked: 
        //  1. Connection
        //  2. Command
        command.Dispose();
        connection.Close();
        connection.Dispose();
    }

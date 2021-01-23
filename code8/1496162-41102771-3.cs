    try 
    {
        SqlConnection connection = new SqlConnection(DBHelper.ConnectionString);
        connection.Open();
        SqlCommand command = new SqlCommand("Some Simple Insert Query", connection);
        try 
        {            
            command.ExecuteNonQuery();
        } 
        finally 
        {
            command.Dispose();
        }
    }
    finally
    {
        connection.Dispose();
    }
    

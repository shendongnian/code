    public void InsertData()
    {
        SqlConnection connection = new SqlConnection(DBHelper.ConnectionString);
       
        try {
          connection.Open();
          SqlCommand command = new SqlCommand("Some Simple Insert Query", connection);
 
          try {
            command.ExecuteNonQuery(); 
          }
          finally { // rain or shine, dispose the resource
            command.Dispose(); 
          }
        }
        finally { // rain or shine, dispose the resource
          connection.Dispose();
        }
 

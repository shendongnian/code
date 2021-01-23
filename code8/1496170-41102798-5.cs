    public void InsertData()
    {
        SqlConnection connection = null;
       
        try {
          connection = new SqlConnection(DBHelper.ConnectionString);
          connection.Open();
          SqlCommand command = null;
 
          try {
             command = new SqlCommand("Some Simple Insert Query", connection);
             command.ExecuteNonQuery(); 
          }
          finally { // rain or shine, dispose the resource (if it has been created)
            if (command != null)
              command.Dispose(); 
          }
        }
        finally { // rain or shine, dispose the resource (if it has been created)
          if (connection != null)
            connection.Dispose();
        }
 

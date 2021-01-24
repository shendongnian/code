    try
    {    
        if (con.State == System.Data.ConnectionState.Closed)
          con.Open();    
    // Set up a command with the given query and associate
    // this with the current connection.
       SqlCommand cmd = new SqlCommand("Backup database " + DBName + " to disk='" + 
       filePathExist + "'", con);
       cmd.CommandTimeout = 60;
       cmd.ExecuteNonQuery();    
    }    
    catch(Exception ex)
    {
       //handle exception here
    }
    finally
    {
        con.Close();
        con.Dispose();
        SqlConnection.ClearPool(con);
    }

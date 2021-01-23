    public bool CheckForExistingAdmin(int level)
    {
        if(level != 1)
           return false;
         
         int count = 0;
     
         using(MySqlConnection conn = new MySqlConnection ("ConnectionString")
         {
             conn.Open();
             
             MySqlCommand cmd = new MySqlCommand();
             cmd.Connection = conn;
             cmd.CommandText = @"SELECT Count(ID) FROM Users WHERE Level = 1";
             
             count = (int)cmd.ExecuteScalar();
    
          }
          
          return count > 0 ? true : false;
    }

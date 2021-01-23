       // wrap IDisposable into using
       // do not hardcode the connection string
       using (SqlConnection con = new SqlConnection(/*read the connection string here*/)) {
         con.Open();
      
         // Make Sql being readable 
         // You don't want at least Username field to be returned (you have in textBox1.Text)
         string sql = 
           @"select Permissions, --TODO: put right fields here
                    Status
               from Creds
              where PasswordHash = @prm_PasswordHash and -- do not store password as plain text
                    Username = @prm_UserName"; 
    
         // wrap IDisposable into using
         using (SqlCommand cmd = new SqlCommand(sql, con)) {
           // do not store password as plain text
           //TODO: AddWithValue is not the best choice; put actual parameter types here 
           cmd.Parameters.AddWithValue("@prm_PasswordHash", ComputeHash(textBox2.Text));
           cmd.Parameters.AddWithValue("@prm_UserName", textBox1.Text);
    
           using (dr = cmd.ExecuteReader()) {
             while (dr.Read()) {
               ...
             }
           } 
         }
       }

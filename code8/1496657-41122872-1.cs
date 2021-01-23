     using(MySqlConnection con = new MySqlConnection(.....constring here....))
     using(MySqlCommand cmd2 = new MySqlCommand(Query2, con))
     using(MySqlCommand cmd3 = new MySqlCommand(Query3, con))
     using(MySqlCommand cmd4 = new MySqlCommand(Query4, con))     
     {
          con.Open();
          // Add the parameter to the first command
          cmd2.Parameters.Add("@uname", MySqlDbType.VarChar).Value = usernameInputBox.Text;
          // run the first command
          cmd2.ExecuteNonQuery();
          // Add parameters to the second command
          cmd3.Parameters.Add("@uname", MySqlDbType.VarChar).Value = usernameInputBox.Text;
          cmd3.Parameters.Add("@upass", MySqlDbType.VarChar).Value =  passwordInputBox.Text;
         // Run the second command, but this one
         // contains two statement, the first inserts, the 
         // second returns the LAST_INSERT_ID on that table, we need to
         // catch that single return
         int userID = (int)cmd3.ExecuteScalar();
         // Run the third command 
         // but first prepare the parameters
         cmd4.Parameters.Add("@insurance", MySqlDbType.VarChar).Value = nationalInsuranceInputBox.Text;
         cmd4.Parameters.Add("@userid", MySqlDbType.Int32).Value = userID;
         .... and so on for all other parameters
         .... using the appropriate MySqlDbType for the column type
         cmd4.ExecuteNonQuery();
    }
         

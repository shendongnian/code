       using (SqlConnection con = new    SqlConnection(constring))
       {
           con.Open();
           using (SqlCommand command = new   SqlCommand("DELETE FROM dbo.Admin WHERE  UserName  = '" + txtUserName.Text +"'", con))
           {
               if( command.ExecuteNonQuery() > 0)
                  MessageBox.Show("Successful operation!");
           }
           con.Close();
      }

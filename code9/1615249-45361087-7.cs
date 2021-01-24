    string sqlQuery = @"Select * from [Table] 
                        Where username = @user AND 
                              password = @pass";
    using(SqlConnection sqlConn = new SqlConnection(....))
    using(SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn))
    {
         sqlConn.Open();
         cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = txtEnterUserName.Text.Trim();
         cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = txtEnterPassword.Text.Trim();
         using(SqlDataReader reader = cmd.ExecuteReader())
         {
             if(reader.HasRows)
             {
                  loginMain objFormMain = new loginMain();
                  this.Hide();
                  UserDashboard userDash = new UserDashboard();
                  userDash.Show();
             }
             else
             {
                  MessageBox.Show("Check Username and Password");
             }
        }
    }

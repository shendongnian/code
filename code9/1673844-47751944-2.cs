       using (var Con = Connections.Create())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = Con;
                        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.CommandText = "Select Name, Id, Center, ClientCode, imgImage, SMSAPI, SenderId, SMSUserName from AdminControl where [UserName]= ? and [Password] = ? ";
                        Con.Open();                        
                        using (OleDbDataReader LoginDr = cmd.ExecuteReader())
                        {
                            if (LoginDr.HasRows)
                            {
                                while (LoginDr.Read())
                                {
                                    // My work
                                }
                            }
                        }
                    }
                }

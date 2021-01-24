       using (var Con = Connections.Create())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = Con;
                        cmd.Parameters.AddWithValue("@p1", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
                        cmd.CommandText = "Select Name, Id, Center, ClientCode, imgImage, SMSAPI, SenderId, SMSUserName from AdminControl where [UserName]= @p1 and [Password] = @p2 ";
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

     private void button2_Click(object sender, EventArgs e)
        {
            
 
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    string query = "SELECT isActive FROM tblUser WHERE username = ?username AND password = ?password";
                    MySqlCommand cmd = new MySqlCommand(query, con.connection);
          
                        cmd.Parameters.AddWithValue("?username", username);
                        cmd.Parameters.AddWithValue("?password", password);
                        con.connection.Open();
                        MySqlDataReader mdr = cmd.ExecuteReader();
                        
                        string isActive="";
                        string updatequery = "UPDATE tbluser SET DateLastLogin= '" + DateTime.Today.ToString("dd-mm-yy") + "',TimeLastLogin = '" + DateTime.Now.TimeOfDay + "', IsActive = 1 WHERE username = ?username";
                        if (mdr.HasRows)
                        {
                            
                            while (mdr.Read())
                            {
                                isActive = mdr[0].ToString();
                                if (isActive.Equals("1"))
                                {
                                    MessageBox.Show("This user is already logged in!");
                                }
                                else
                                {
                                    MySqlCommand updatecmd = new MySqlCommand(updatequery, con.connection2);
                                    con.connection2.Open();
                                        updatecmd.Parameters.AddWithValue("?username", username);
                                        updatecmd.ExecuteNonQuery();
                                        pnlLogin.Hide();
                                        pnlMenu.Show();
                                        MessageBox.Show("Welcome " + username);
                                    
                                }
                                
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Invalid user credentials.");
                        }
                        con.CloseConnection();
           
        }

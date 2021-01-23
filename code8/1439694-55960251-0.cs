    MySqlCommand SelectCommand = new MySqlCommand("select * from boardinghousedb.employee_table where username='" + this.txtUsername.Text + "' and password='" + this.txtPassword.Text + "' ;", myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();
                    int count = 0;
                    string userRole = string.Empty;
                    while (myReader.Read())
                    {
                        count = count + 1;
                        userRole = myReader["UserRole"].ToString();
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Username and Password . . . is Correct", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Hide();
                        if(userRole =="Admin")
                        //show admin window
                        else
                        //show user window
                        Menu mm = new Menu();
                        mm.ShowDialog();
                    }
                  else if (count > 1)
                  { MessageBox.Show("Duplicate User And Password"); }
                 else
                     MessageBox.Show("Username and Password Incorrect", "Login Error:");
                   myConn.Close();
            }

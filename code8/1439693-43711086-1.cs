                if (txtUsername.Text == "" && txtPassword.Text == "") //Error when all text box are not fill
                {
                    MessageBox.Show("Unable to fill Username and Password", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUsername.Text == "") //Error when all text box are not fill
                {
                    MessageBox.Show("Unable to fill Username", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassword.Text == "") //Error when all text box are not fill
                {
                    MessageBox.Show("Unable to fill Password", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
                else
                {
                    try
                    {
                        string myConnection = "datasource=localhost;port=3306;username=root";
                        MySqlConnection myConn = new MySqlConnection(myConnection);
    
                        MySqlCommand SelectCommand = new MySqlCommand("select * from boardinghousedb.employee_table where username='" + this.txtUsername.Text + "' and password='" + this.txtPassword.Text + "' ;", myConn);
    
                        MySqlDataReader myReader;
    
                        myConn.Open();
                        myReader = SelectCommand.ExecuteReader();
                        int count = 0;
                        while (myReader.Read())
                        {
                            count = count + 1;
                        }
                        if (count == 1)
                        {
                            MessageBox.Show("Username and Password . . . is Correct", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Hide();
                            Menu mm = new Menu();
                            mm.ShowDialog();
                        }
                        else if (count > 1)
                        {
                            MessageBox.Show("Duplicate Username and Password . . . Access Denied", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Username and Password is Not Correct . . . Please try again", "Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            myConn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }       

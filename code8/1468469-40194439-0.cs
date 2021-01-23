    private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text ;
            string password = passwordTextBox.Text ;
            if (checkDatabaseForValidDetails(username,password))
            {
               this.Visible=false;
               Form1 formObject = new Form1();
               formObject.show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
    
        }

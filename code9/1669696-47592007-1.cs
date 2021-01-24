    private void button1_Click(object sender, EventArgs e)
    {
        string[] userdetails = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "UserDetails.txt");
        bool usernameFound = false;
        foreach (string user in userdetails)
        {
            string[] splitDetails = user.Split(':');
            Login.username = splitDetails[0];
            Login.password = splitDetails[1];
            label1.Text = Login.username;
            label2.Text = Login.password;
            if (txtUsername.Text == Login.username)
            {
                if (txtPassword.Text == Login.Password)
                {
                    MessageBox.Show("Welcome " + Login.username);
                    this.Hide();
                    frmMainMenu menu = new frmMainMenu();
                    menu.Show();
                    return; // we're done here, so return instead of break
                }
                usernameFound = true;
                break; // we're not gonna find this username again, so might as well quit the loop
            }
        }
        //we only get there if the credentials were incorrect
        //so we check if the username was found, if yes, the
        //password was incorrect, if not, the username was        
        string message = String.Empty;
        if (usernameFound)
            message = "Password";
        else
            message = "Username";
        message += " incorrect";
        MessageBox.Show(message);
        //or shorten the above 7 lines with a ternary operator
        //MessageBox.Show((usernameFound ? "Password" : "Username") + " incorrect");
    }

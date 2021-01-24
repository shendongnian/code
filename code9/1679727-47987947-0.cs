    private void txtPassword_Leave(object sender, EventArgs e)
    {
        if(txtPassword.Text == "")
        {
            txtPassword.PasswordChar = '\0'; // Note this line!
            txtPassword.Text = "Enter a password...";
            txtPassword.ForeColor = Color.Gray;
        }
    }

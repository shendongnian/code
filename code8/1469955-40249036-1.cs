    using(LoginForm fLogin = new LoginForm())
    {
        if(DialogResult.OK == fLogin.ShowDialog())
        {
             MessageBox.Show("Login OK");
        }
        else
        {
             MessageBox.Show("Login failed");
        }
    }

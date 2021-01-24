    private async void btnLogin_Click (object sender, EventArgs e)
    {
         btnLogin.Enabled = eUsername.Enabled = ePassword.Enabled = false;
         loading.Visible = true;
         ... rest of method
         loading.Visible = false;
         btnLogin.Enabled = eUsername.Enabled = ePassword.Enabled = true;
    }

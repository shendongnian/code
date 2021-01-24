    private void btn_login_Click(object sender, EventArgs e)
    {
        if (dbConnection.CheckUsername(txt_username.Text) == 1 && dbConnection.CheckPassword(txt_password.Text) == 1)
        {
            SetUsername(txt_username.Text);
            SetPassword(txt_password.Text);
            //txt_username.Clear();
            //txt_password.Clear();
            shop1Interface = new ShopInterface();
            // This is the line you need
            shop1Interface.Login = this;
            shop1Interface.Show();
    
        }
    }

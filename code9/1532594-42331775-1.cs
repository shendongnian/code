    private void btn_buyapple_Click(object sender, EventArgs e)
    {
        // Now it will work
        string username = this.Login.GetUsername();
        string password = this.Login.GetPassword();
    
        dbConnection.Transaction(login.GetUsername(), login.GetPassword(), 10);
    }

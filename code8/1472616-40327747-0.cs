    public string userName;
    public string password;
    public void btnLogin_Click(object sender, EventArgs e)
    {
        userName = User.Text;
        password = Password.Text;
    
        this.Visible = false;
    }

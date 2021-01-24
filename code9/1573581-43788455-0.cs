    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string userName = Login1.UserName;
        string password = Login1.Password;
        bool result = IsAuthenticate(userName, password);
        if ((result))
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
    }
    protected bool IsAuthenticate(string username,string password)
    {
        // implement this method according to your database..
    }

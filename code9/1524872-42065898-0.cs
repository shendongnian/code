    var auth = input as Classes.Authentication;
    if(auth != null )
    {
        string Username = auth.Username;
        string Password = auth.Password;
        Classes.Authentication InputAccount = new Classes.Authentication(Username, Password);
    }

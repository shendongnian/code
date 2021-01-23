    string password = PasswordTxt.Text//you should use your control names
    string userName = UserNameTxt.Text//your control
    
    bool validUsers = false;
    foreach (var line in File.ReadLines("@"C:\Users\dagostinom18\Documents\Visual Studio 2015\Projects\Assignment\Assignment\users.txt""))
    {
       string textUserName = line.Split(',')[0].Trim();
       string textPassword = line.Split(',')[1].Trim();
       validUsers = textUserName == userName && textPasword == password;
       
    }
    if(!validUsers)
    {
        //show error, user credentials are not valid
        return;
    }
    //go log in.

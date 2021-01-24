    IEnumerable users = db
        .Query("select Username, Password from UserLog where UserName = @UserName and Password = @Password",
        new {UserName = txtUsername.Text, Password = // put the password here});
    if (users.Any())
    {
        // authenticated so do whatever
    }

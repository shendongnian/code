    var query=database.Table<Users>().Where(i => i.UserName == userNameLogIn 
                                                 && i.Password == passwordLogIn);
    if (query.Any())
    {
        return true;
    }

    public bool queryLogIn(string userNameLogIn,string passwordLogIn)
    {
    var query=database.Table<Users>().FirstOrDefault(i => i.UserName == userNameLogIn && i.Password == passwordLogIn);
    if (query == null)//There is error
    {
        return false;
    }
    else
    {
        return true;
    }                
    }

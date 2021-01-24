    public IObject Register(string username)
    {
        var obj = new AccountProcess().CreateAccount(username);
        return ApiReturnFactory.CreateInstance(obj);
    }

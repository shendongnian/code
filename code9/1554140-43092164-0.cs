    public obj2<T> Register<T>(string username)
    {
        var result = new AccountProcess().CreateAccount(username);
        return ApiReturnFactory.CreateInstance(result);
    }

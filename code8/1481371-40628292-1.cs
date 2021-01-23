    public void GenerateGuid()
    {
        var guid = MyUserIdProvider.UserId(Context.Request);
        Clients.Caller.myGuid(guid);
    }

    private object Connect(Type clientType, Type queryType, Type filterType, Type authType, string code)
    {
        dynamic client = Activator.CreateInstance(clientType);
        client.Endpoint.Address = EndPoint;
        dynamic query = Activator.CreateInstance(queryType);
        dynamic filter = Activator.CreateInstance(filterType);
        filter.param_code = code;
        query.Filter = filter;
        dynamic auth = Activator.CreateInstance(authType);
        auth.Username = _username;
        auth.Password = _password;
        return client.Query(auth, query).Records;
    }

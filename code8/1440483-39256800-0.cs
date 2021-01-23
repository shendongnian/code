    public static async Task<Client> GetMap(Client client, Func<Task<Data.Models.Client>, Client> func)
    {
        var map = Mapper.Map<Client, Data.Models.Client>(client);
        var ret = await func(map);
        return Mapper.Map<Data.Models.Client, Client>(ret);
    }
    public static Task<Client> GetMap(Client client, Func<Data.Models.Client>, Client> func)
    {
        var map = Mapper.Map<Client, Data.Models.Client>(client);
        var ret = func(map);
        return Mapper.Map<Data.Models.Client, Client>(ret);
    }

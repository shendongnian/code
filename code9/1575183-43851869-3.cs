    private async Task<Item> InitializeAsync()
    {
        typename = await ESIGenericRequests.GetTypeNameAsString(typeid);
        systemname = await ESIGenericRequests.GetSystemNameAsString(systemid);
        return this;
    }
    public static Task<Item> CreateAsync()
    {
        var ret = new Item();
        return ret.InitializeAsync();
    }

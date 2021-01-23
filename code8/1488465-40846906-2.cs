    public Task<Item> AddItem(Item item) { 
    return Task.Run(async () => { 
        var param = ... params ... 
        await _client.Post<string>("/item", param); 
        return item; 
    }); 

    public async Task<Item> AddItem(Item item) { 
        var param = ... params ... 
        await _client.Post<string>("/item", param); 
        return item; 
    }

    public async Task<Something> GetSomethingAsync()
    {
        var somethingService = new SomethingService();
        // Here execution returns to the caller and returned back only when Task is completed.
        Something value = await service.GetAsync(); 
        DoSomething();
        return value;        
    }

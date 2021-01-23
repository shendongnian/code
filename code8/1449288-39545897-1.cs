    public async Task<Something> GetSomethingAsync()
    {
        var somethingService = new SomethingService();
        Task<Something> valueTask = service.GetAsync(); 
        DoSomething();
        return valueTask;        
    }

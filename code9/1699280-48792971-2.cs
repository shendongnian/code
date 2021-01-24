    public Task<int> getNumber()
    {
         return getFirstNumber();    
    }
    public Task<int> getFirstNumber()
    {
         return Task.FromResult(1);
    }

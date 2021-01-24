    public async Task A()
    {
       await B();
       //some code that interacts with the UI
    }
    
    public async Task<bool> B()
    {
       var result= await C().ConfigureAwait(false); 
       //some code does does not interact with the UI
       return result; 
    }
    public Task<bool> C()
    { 
       // not implemnted
    }

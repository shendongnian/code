    public async Task A()
    {
       await B();
       //some code
    }
    
    public Task<bool> B()
    {
       return C(); 
    }
    public Task<bool> C()
    { 
       // not implemnted
    }

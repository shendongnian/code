    public void Foo(int a, bool useDB, DbContext dbContext = null)
    {
        if(useDB && dbContext == null)
        {
            throw new Exception("DB context must be supplied!");
        }
    
        //...
    }

    using(var repository = work
                     .Timeout(TimeSpan.FromSeconds(5))
                     .WithRepository(c => c.Users)
                     .Do(r => r.LoadByUsername("matt"))
                     .Execute())
    {
    
       IUser user = repository.Result;
       //repository.Dispose();
    }
    //******
    public TResult Result { get; set; }
    
    public IActionFlow<IUserRepository> Execute()
    {
        // ...
        //Dispose();
        this.Result = result;
        return this;
    }

    public DbContext() : base("name=DbContext", "DbContext")
    {
        this.Configuration.LazyLoadingEnabled = false;
        OnContextCreated();
    }

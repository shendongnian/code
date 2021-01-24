    public MyEntitiesContext() : base("name=MyEntitiesContext", "MyEntitiesContext")
    {
        this.Configuration.LazyLoadingEnabled = false;
        OnContextCreated();
    }

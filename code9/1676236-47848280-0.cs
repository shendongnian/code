    public YourContext(bool lasyLoadingEnabled) : base("DefaultConnection")
    {
        Database.SetInitializer<NimasContext>(null);
        this.Configuration.LazyLoadingEnabled = lasyLoadingEnabled;
        this.Configuration.ProxyCreationEnabled = false; ;
    }

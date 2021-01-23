    public DataContext() : base("your connectionstring")               
        **this.Database.Connection.Open();**
        this.Configuration.LazyLoadingEnabled = false;
        this.Configuration.ProxyCreationEnabled = false;
    }
        

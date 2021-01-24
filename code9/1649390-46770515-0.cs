    public DataContext() : base("name=MyDB")
    {
    	Database.SetInitializer<DataContext>(new CategoryInitializer<DataContext>());
    	Database.Initialize(true);
    }

    public MyDbContext() : base("MyDbConnectionString")
    {
        //TODO: Remove initializer
        Database.SetInitializer<MyDbContext>(new DropCreateDatabaseAlways<MyDbContext>());
        Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());
    }

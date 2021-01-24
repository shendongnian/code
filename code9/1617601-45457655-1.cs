    MyDbContext.ConnectionStringProvider = () => "MyTestConnectionStringName";
    using (var ctx = new MyDbContext())
    {
        // This code will use conn string named MyTestConnectionStringName
    }

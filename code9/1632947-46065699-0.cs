    Public ApplicationContext:DbContext
    {
    Public ApplicationContext():base(“ConnectionStringName”)
    {
    Database.SetInitializer<ApplicationContext>(null);
    }
    //Dbsets here
    }

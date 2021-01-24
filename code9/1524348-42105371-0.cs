    public class ExampleDBContext: DbContext 
    {        
      public ExampleDBContext(): base("AConnectionString") 
      {
        Database.SetInitializer<ExampleDBContext>(new CreateDatabaseIfNotExists<ExampleDBContext>());
      }
    }
    

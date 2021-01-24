    public class YourDBContext: DbContext 
    {
            
            public YourDBContext(): base("YourDBContextConnStr") 
            {
                Database.SetInitializer<YourDBContext>(new CreateDatabaseIfNotExists<YourDBContext>());
        
            }
    }
   

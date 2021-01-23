    services.AddSingleton<dbContext>(_ => new dbContext(Configuration.GetConnectionString("...")));
    public class dbContext : DbContext
    {
         public dbContext(string dbConnection) : base(dbConnection)
         {
    
         }
    }

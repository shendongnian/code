    public class MyDbContext: DbContext //IdentityDbContext 
    {
         public MyDbContext() : base("name=ConnectionStringNameFrom .config")
         {
              Database.Log = e => Debug.WriteLine(e); 
              //or you can define it like this: Database.Log = Console.WriteLine; 
         }
         //{...} your DbSets properties
         //protected override void OnModelCreating(DbModelBuilder modelBuilder)
         //{
         // {...}
         //}
    }

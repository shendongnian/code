    public class MyDbContext : DbContext 
    { 
        public MyDbContext () : base("YourDefaultConnectionString")
		{		    
            // Database Initializer 
		}
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
           // Write your own model creation code;  
         }
    }

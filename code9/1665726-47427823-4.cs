        public class ApplicationDbContext : DbContext //change DbContext name appDbContext by ApplicationDbContext
            {
                public DbSet<Appointments> Appointments { get; set; }
            
                public ApplicationDbContext(database=""): base("name=DefaultConnection")
                {
              //And/Or you can do this programmatically.
              if(!string.IsNullOrWhiteSpace(database)
                 {
                   this.Database.Connection.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=" + database + ";Integrated Security=True";
     //OR Database.Connection.ChangeDatabase(database);
                 }
                // More Stuff.....
                }
            }

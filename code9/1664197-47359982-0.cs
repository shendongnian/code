    public class MyDatabase: DbContext
    {
        public MyDatabase(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }
        public DbSet<Order> Orders{ get; set; }
    }

    public class CommonsDbContext : DbContext
    {
        //Approach 1:
        private const connectionString = "...";
        public CommonsDbContext() : base(connectionString)
        {
            Database.SetInitializer<CommonsDbContext>(null);
        }
        //Approach 2:
        public static CommonsDbContext GetContext()
        {
            var builder = new SqlConnectionStringBuilder();
            // add data here
            return new CommonsDbContext(builder.ConnectionString);
        }
        private CommonsDbContext(string connString) : base(connString)
        {
            Database.SetInitializer<CommonsDbContext>(null);
        }
    }

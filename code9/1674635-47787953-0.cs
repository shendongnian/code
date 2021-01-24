    static class DbContextExtensions
    {
        public static void SaveConnectionString (this DbContext dbContext)
        {
             string connectionString = dbContext.Database.Connection.ConnectionString;
             SaveConnectionString(connectionString);
        }
        private static void SaveConnectionString(string connectionString)
        {   // save the string where you want it, for instance app.config
            // out of scope of this question
        }
    }

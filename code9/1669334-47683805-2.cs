        public static class DbContextFactory
        {
            public static Dictionary<string, string> ConnectionStrings { get; set; }
            public static void SetConnectionString(Dictionary<string, string> connStrs)
            {
                ConnectionStrings = connStrs;
            }
            public static AppContext Create(string connid)
            {
                if (!string.IsNullOrEmpty(connid))
                {
                    var connStr = ConnectionStrings[connid];
                    var optionsBuilder = new DbContextOptionsBuilder<AppContext >();
                    optionsBuilder.UseSqlServer(connStr);
                    var db = new AppContext (optionsBuilder.Options);
                    return db;
                }
                else
                {
                    throw new ArgumentNullException("Connection failed becuase of no Connection ID");
                }
           } 
        }

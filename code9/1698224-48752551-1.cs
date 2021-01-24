        protected DatabaseApplicationContext()
        {
            Database.Migrate();            
        }
        public DatabaseApplicationContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

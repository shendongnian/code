        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<EngineDataContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

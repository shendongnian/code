        class MigrationHistoryEntry
        {
            public string MigrationId { get; set; }
            public string ContextKey { get; set; }
            public string Model { get; set; }
            public string ProductVersion { get; set; }
        }
        public void GetMigrations()
        {
            const string GetMigrationSql = "SELECT * FROM __MigrationHistory";
            var migrations = Context.Database.SqlQuery<MigrationHistoryEntry>(GetMigrationSql);
        }

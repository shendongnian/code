    class MyContext : DbContext
    {
        public DbSet<AppliedMigration> AppliedMigrations { get; set; }
    }
    [Table("__EFMigrationsHistory")]
    class AppliedMigration
    {
        [Column("MigrationId")]
        public string Id { get; set; }
        [Column("ProductVersion")]
        public string EFVersion { get; set; }
    }

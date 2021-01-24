    class MyDbContext : DbContext
    {
        DbSet<...> ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             // Configure that all used DateTime should be modelled datetime2:
             const string standardDateTimeType = "datetime2";
             modelBuilder.Properties<DateTime>()
                 .Configure(p => p.HasColumnType(standardDateTimeType);
             ...
        }
 

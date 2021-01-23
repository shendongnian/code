    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string SQLLiteConnectionString = @"Data Source=C:/Projects/ArticlesDB.db";
                optionsBuilder.UseSqlite(SQLLiteConnectionString);             
            }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Articles>().ToTable("Articles");
                modelBuilder.Entity<Articles>(entity =>
                {
                    entity.Property(e => e.Id).IsRequired();
                });
            }

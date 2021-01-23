    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailyLog>().Map(m =>
        {
            m.Properties(p => new { p.Id, p.Date});
            m.ToTable("DAILYLOG");
        });
        modelBuilder.Entity<HeartRatePattern>().ToTable("DAILYLOG").Property(x => string.Join(";",x.HeartRate)).HasColumnType("varchar");
    }

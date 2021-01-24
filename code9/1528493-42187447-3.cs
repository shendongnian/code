    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Ads>().
                HasMany(c => c.AdsCategories).
                WithMany(p => p.Ads).
                Map(
                    m =>
                    {
                        m.MapLeftKey("AdsId");
                        m.MapRightKey("AdsCategoryId");
                        m.ToTable("Whateveryoucallyourtable");
                    });
     }

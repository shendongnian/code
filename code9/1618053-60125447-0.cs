    protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Office>(entity =>
                    {
                        entity.HasKey(x=>x.OfficeID);
        
                    });
                }

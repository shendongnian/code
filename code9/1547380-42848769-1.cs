    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<Role>()
                    .HasMany<Premission>(s => s.Premissions)
                    .WithMany(c => c.Roles)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("RoleRefId");
                                cs.MapRightKey("PremissionRefId");
                                cs.ToTable("Role_Premission");
                            });
    
    }

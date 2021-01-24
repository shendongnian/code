    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {          
            
       base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<ApplicationUser>(b =>
                {
                    //Each User can have many entries in the UserRole join table
                    b.HasMany(e => e.Roles)
                        .WithOne()
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                });
    }

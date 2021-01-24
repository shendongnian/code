    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Documents)
                .WithRequired(d => d.UserId)
                .WillCascadeOnDelete(false);
          
            base.OnModelCreating(modelBuilder);
        }

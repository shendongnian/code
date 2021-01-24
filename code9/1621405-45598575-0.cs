    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //your problem is in this line change IdentityRole  to CustomRole 
            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(255);
        }

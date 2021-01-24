    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<Process>()
                .HasMany(p => p.RelatedProcesses)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ProcessId");
                    m.MapRightKey("RelatedID");
                    m.ToTable("Process_Related");
                });
        }

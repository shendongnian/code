    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasMany(p => p.Cast).WithMany(p => p.ActingCredits);
            modelBuilder.Entity<Actor>().HasMany(m => m.ActingCredits).WithMany(m => m.Cast);
        }

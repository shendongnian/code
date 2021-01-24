    class MyContext : DbContext
    {
        // Your DbSets
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TireCar>()
                .HasOne(tc => tc.car)
                .WithMany(car => car.tires)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

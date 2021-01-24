      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherData>().Property(a => a.VendorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<WeatherData>().Property(a => a.WeatherStationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<WeatherData>().HasKey(w => new
            {
                w.VendorId,
                w.WeatherStationId
            });
        }

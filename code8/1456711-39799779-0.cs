    modelBuilder.Entity<Entity>().HasKey(p => p.Id);
            modelBuilder.Entity<Entity>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Entity>().Property(p => p.TimeStamp).IsRowVersion();
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.ComplexType<Location>();

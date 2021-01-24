    modelBuilder.Entity<Movie>()
                .HasMany(a => a.Actors)
                .WithMany(a => a.Movies_Actors)
                .Map(x =>
                {
                    x.MapLeftKey("Movie_ID");
                    x.MapRightKey("Person_ID");
                    x.ToTable("Movie_Actor");
                });
    
    modelBuilder.Entity<Movie>()
    .HasRequired<Person>(s => s.Director)
    .WithMany(s => s.Movies_Directors);

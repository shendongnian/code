            builder.Entity<ApplicationUser>()
                    .HasOne(c => c.Country)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);
    
            builder.Entity<ApplicationUser>()
                    .HasOne(c => c.State)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);
    
            builder.Entity<ApplicationUser>()
                    .HasOne(c => c.City)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Price>()
                .HasKey(input => input.PriceId)
                .HasName("PrimaryKey_Price_PriceId");
            // Provide the properties of the PriceId column
            modelBuilder.Entity<Price>()
                .Property(input => input.PriceId)
                .HasColumnName("PriceId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();
            //modelBuilder.Entity<Price>()
            //    .Property(input => input.MetricId)
            //    .HasColumnName("MetricId")
            //    .HasColumnType("int")
            //    .IsRequired();
            modelBuilder.Entity<Price>()
                .Property(input => input.Value)
                .HasColumnName("Value")
                .HasColumnType("DECIMAL(19,4)")
                .IsRequired();
            modelBuilder.Entity<Price>()
                .Property(input => input.RRP)
                .HasColumnName("RRP")
                .HasColumnType("DECIMAL(19,4)")
                .IsRequired(false);
            modelBuilder.Entity<Price>()
                .Property(input => input.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Price>()
                .Property(input => input.DeletedAt)
                .IsRequired(false);
            // Two sets of Many to One relationship between User and ApplicationUser  entity (Start)
            modelBuilder.Entity<Price>()
             .HasOne(userClass => userClass.CreatedBy)
             .WithMany()
             .HasForeignKey(userClass => userClass.CreatedById)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired();
            modelBuilder.Entity<Price>()
                .HasOne(userClass => userClass.DeletedBy)
                .WithMany()
                .HasForeignKey(userClass => userClass.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

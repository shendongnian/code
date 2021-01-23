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

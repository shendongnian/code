    var entityBuilder = modelBuilder.Entity<SomeEntity>();
    entityBuilder.Property(someEntity => someEntity.SomeProperty)
                 .HasColumnType("char")
                 .HasMaxLength(10)
                 .IsRequired();

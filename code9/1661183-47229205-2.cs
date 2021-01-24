    builder.Entity<MyEntity>()
      .ToTable("MyTable", "MySchema")
      .Property(e => e.Name, 
        n => n.IsRequired()
              .HaxMaxLength(10))
      .Property(e => e.City,
        c => c.HasxMaxLength(50));

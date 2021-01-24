    foreach (var property in modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal)))
    {
        // EF Core 1 & 2
        property.Relational().ColumnType = "decimal(18, 6)";
        // EF Core 3
        //property.SetColumnType("decimal(18, 6)");
    }

    foreach (PropertyBuilder pb in builder.Model
        .GetEntityTypes()
        .Where(x=>typeof(IEntity).IsAssignableFrom(x.ClrType))
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(Guid) && p.Name == nameof(IEntity.Id))
        .Select(p => builder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
    {
        pb.ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()");
    }

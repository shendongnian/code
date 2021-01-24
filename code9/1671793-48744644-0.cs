    builder.Model.GetEntityTypes()
                           .Where(entityType => typeof(IDeletableEntity).IsAssignableFrom(entityType.ClrType))
                           .ToList()
                           .ForEach(entityType =>
                           {
                               builder.Entity(entityType.ClrType)
                               .HasQueryFilter(ConvertFilterExpression<IDeletableEntity>(e => !e.IsDeleted, entityType.ClrType));
                           });
    

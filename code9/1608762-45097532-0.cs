    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    ...
    
    private static void SetSoftDeleteFilter<TEntity>(EntityTypeBuilder<TEntity> typeBuilder)
        where TEntity : class, ISoftDeleteModel
    {
        typeBuilder.HasQueryFilter(x => !x.IsDeleted);
    }
    
    ...
    
    foreach (var type in modelBuilder.Model.GetEntityTypes())
    {
        if (typeof(ISoftDeleteModel).IsAssignableFrom(type.ClrType))
            SetSoftDeleteFilter((dynamic)modelBuilder.Entity(type.ClrType));
    }

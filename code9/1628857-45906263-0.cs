    Type targetType = typeof(IEntity<>);
    var entityType = entity.GetType();
    if (entityType.IsGenericType 
        && targetType.IsAssignableFrom(entityType.GetGenericTypeDefinition())) {
    }

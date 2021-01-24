    public static TEntity InitializeEntity<TEntity>(TEntity entity)
    {
        var properties = entity.GetType().GetProperties();
        foreach (var prop in properties)
        {
            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
            {                                        
                //check if property is null or if get some value, dont want to rewrite values from database
                var value = prop.GetValue(entity);
                if (value == null) {
                    var itemType = prop.PropertyType.GetGenericArguments()[0];
                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(itemType);
                    prop.SetValue(entity, Activator.CreateInstance(constructedListType));
                }
            }
        }
        return entity;
        }

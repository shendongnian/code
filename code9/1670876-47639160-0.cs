    public void FindSpecialProperties(PropertyInfo property,List<PropertyInfo> allProperties)
    {
        var properties = property.PropertyType.GetProperties();
        if (properties.Length == 0)
        {
            return;
        }
        foreach (var propertyInfo in properties)
        {
            var singleNestedPropertyIndex = propertyInfo.GetCustomAttribute<SingleIndexAttribute>();
            var groupNestedIndex = propertyInfo.GetCustomAttribute<GroupIndexAttribute>();
            var ttlIndex = property.GetCustomAttribute<TTLIndexAttribute>();
            if (singleNestedPropertyIndex != null || groupNestedIndex != null || ttlIndex != null)
            {
                allProperties.Add(propertyInfo);
            }
            RecursiveTypeProperties(propertyInfo, allProperties);
        }
    }

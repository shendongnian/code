    HashSet<PropertyInfo> visitedProperties = new HashSet<PropertyInfo>();
    List<PropertyInfo> remainingProperties = type.GetProperties().ToList();
    List<PropertyInfo> foundProperties = new List<PropertyInfo>();
    while (remainingProperties.Count > 0)
    {
        var currentProperty = remainingProperties[0];
        remainingProperties.RemoveAt(0);
        // Process this property if we haven't visited it yet
        if (!visitedProperties.Contains(currentProperty))
        {
            // Add the property to the set of visited properties
            visitedProperties.Add(currentProperty);
            // Add sub-properties to the remaining property list if we haven't visited them
            var nestedProperties = currentProperty.PropertyType.GetProperties();
            foreach (var nestedProperty in nestedProperties)
            {
                if (!visitedProperties.Contains(nestedProperty))
                {
                    visitedProperties.Add(nestedProperty);
                }
            }
            // Check the current property for attributes
            var singleNestedPropertyIndex = nestedProperty.GetCustomAttribute<SingleIndexAttribute>();
            var groupNestedIndex = nestedProperty.GetCustomAttribute<GroupIndexAttribute>();
            var ttlIndex = property.GetCustomAttribute<TTLIndexAttribute>();
            if (singleNestedPropertyIndex != null || groupNestedIndex != null || ttlIndex != null)
            {
                foundProperties.Add(nestedProperty);
            }
        }
    }

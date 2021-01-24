    HashSet<PropertyInfo> visitedProperties = new HashSet<PropertyInfo>();
    Stack<PropertyInfo> remainingProperties = new Stack<PropertyInfo>(type.GetProperties());
    List<PropertyInfo> foundProperties = new List<PropertyInfo>();
    while (remainingProperties.Count > 0)
    {
        var currentProperty = remainingProperties.Pop();
        // Process this property if we haven't visited it yet
        // Add returns true if the element is not yet in the set
        if (visitedProperties.Add(currentProperty))
        {
            // Add sub-properties to the remaining property list if we haven't visited them
            var nestedProperties = currentProperty.PropertyType.GetProperties();
            foreach (var nestedProperty in nestedProperties)
            {
                if (!visitedProperties.Contains(nestedProperty))
                {
                    remainingProperties.Push(nestedProperty);
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

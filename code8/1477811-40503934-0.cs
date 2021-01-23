    Type listElementType = property.PropertyType.GenericTypeArguments[0];
    Type constructedListType;
    if (! property.PropertyType.IsGenericTypeDefinition)
        constructedListType = property.PropertyType;
    else
    {
        // Depending on where your property comes from
        // This should not work in the case the property type is List<T>
        // How listElementType should allow you to instantiate your type ?
        var listType = property.PropertyType.GetGenericTypeDefinition();
        constructedListType = listType.MakeGenericType(listElementType);
    }

    private static object GetPropertyValue(PropertyInfo property, object instance)
    {
        Type root = instance.GetType();
        if (property.DeclaringType == root)
            return property.GetValue(instance);
        object subInstance = root.GetProperty(property.DeclaringType.Name).GetValue(instance);
        return GetPropertyValue(property, subInstance);
    }

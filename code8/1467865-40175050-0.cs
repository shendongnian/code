    static IDictionary<Type, object> DefaultValues = new Dictionary<Type, object>();
    static bool IsBoxedDefault(object boxedProperty)
    {
        if (boxedProperty == null)
            return true;
        Type objectType = boxedProperty.GetType();
        if (!objectType.IsValueType)
        {
            // throw exception or something else?? Up to how you want this to behave
            return false;
        }
        object defaultValue = null;
        if (!DefaultValues.TryGetValue(objectType, out defaultValue))
        {
            defaultValue = Activator.CreateInstance(objectType);
            DefaultValues[objectType] = defaultValue;
        }
        return defaultValue.Equals(boxedProperty);
    }

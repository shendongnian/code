    Boolean isKeyValuePair = false;
    Type type = arguments.GetType();
    if (type.IsGenericType)
    {
        Type[] genericTypes = type.GetGenericArguments();
        if (genericTypes.Length == 1)
        {
            Type underlyingType = genericTypes[0];
            if (underlyingType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
                isKeyValuePair = true;
        }
    }

    Boolean isKeyValuePair = false;
    Type type = arguments.GetType();
    if (type.IsGenericType)
    {
        Type[] genericTypes = type.GetGenericArguments();
        if (genericTypes.Length == 1)
        {
            Type underlyingType = genericTypes[0];
            if (underlyingType.GetGenericTypeDefinition() == typeof (KeyValuePair<,>))
            {
                Type[] kvpTypes = underlyingType.GetGenericArguments();
                Type kvpType = typeof(KeyValuePair<,>);
                kvpType = kvpType.MakeGenericType(kvpTypes);
                Type listType = typeof (List<>);
                listType = listType.MakeGenericType(kvpType);
                dynamic list = Activator.CreateInstance(listType);
                foreach (dynamic argument in (IEnumerable)arguments)
                    list.Add(Activator.CreateInstance(kvpType, argument.Key, argument.Value));
            }
        }
    }

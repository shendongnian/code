    /// <summary>Get the key=>value pairs represented by a dictionary, enumeration of KeyValue pairs or an anonymous object.</summary>
    private IEnumerable<KeyValuePair<string, object>> GetArguments(object arguments)
    {
        // null
        if (arguments == null)
            return Enumerable.Empty<KeyValuePair<string, object>>();
    
        // dictionary
        if (arguments is IDictionary dictionary)
            return dictionary
                .Cast<dynamic>()
                .Select(item => new KeyValuePair<string, object>(item.Key.ToString(), item.Value));
    
        // enumeration
        if (arguments is IEnumerable enumeration)
        {
    #if NETFULL
            var argumentsType = enumeration.GetType();
            var itemType = argumentsType.GetElementType();
            var isGeneric = itemType.IsGenericType;
            var enumeratedType = isGeneric ? itemType.GetGenericTypeDefinition() : null;
    #else
            var argumentsTypeInfo = enumeration.GetType().GetTypeInfo();
            var itemTypeInfo = argumentsTypeInfo.GetElementType().GetTypeInfo();
            var isGeneric = itemTypeInfo.IsGenericType;
            var enumeratedType = isGeneric ? itemTypeInfo.GetGenericTypeDefinition() : null;
    #endif
    
            if (enumeratedType == typeof(KeyValuePair<,>))
            {
                return enumeration
                    .Cast<dynamic>()
                    .Select(item => new KeyValuePair<string, object>(item.Key.ToString(), item.Value));
            }
            else
            {
                throw new ArgumentException("You must provide an enumeration of KeyValuePair", nameof(arguments));
            }
        }
    
        // object
        return arguments.GetType()
            .GetRuntimeProperties()
            .Where(p => p.CanRead)
            .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(arguments)));
    }

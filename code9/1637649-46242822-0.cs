    public static Type GetUnderlyingType(object paramValue)
    {
        Type type = paramValue.GetType();
        var stringType = typeof(string);
        if (type == stringType)
            return stringType;
        else if (type.IsArray)
            type = type.GetElementType();
        else if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
            type = ((System.Collections.IEnumerable)paramValue).GetType().GetGenericArguments()[0]; ;
        return type;
    }

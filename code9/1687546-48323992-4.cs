    public static Type GetGenericTypeOfEnumerable(object o)
    {
        Type firstGenericType = o.GetType().GetInterfaces()
            .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .Select(t => t.GetGenericArguments()[0])
            .FirstOrDefault();
        return firstGenericType;
    }

    public bool Equals(Type x, Type y)
    {
        var a = x.IsGenericType ? x.GetGenericTypeDefinition() : x;
        var b = y.IsGenericType ? y.GetGenericTypeDefinition() : y;
        return a == b;
    }

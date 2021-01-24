    public static IEnumerable TupleToEnumerable(object tuple)
    {
        Type t = tuple.GetType();
        if (isTupleType(t))
        {
            for (int i = 1;; ++i)
            {
                var prop = t.GetProperty("Item" + i);
                if (prop == null)
                    yield break;
                yield return prop.GetValue(tuple);
            }
        }
    }
    private static bool isTupleType(Type type)
    {
        if (!type.IsGenericType)
            return false;
        var def = type.GetGenericTypeDefinition();
        for (int i = 2;; ++i)
        {
            var tupleType = Type.GetType("System.Tuple`" + i);
            if (tupleType == null)
                return false;
            if (def == tupleType)
                return true;
        }
    }

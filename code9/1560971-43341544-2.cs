    public static IEnumerable TupleToEnumerable(object tuple)
    {
        Type t = tuple.GetType();
        if (t.IsGenericType && t.GetGenericTypeDefinition().FullName.StartsWith("System.Tuple"))
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

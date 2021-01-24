    public static IEnumerable TupleToEnumerable(object tuple)
    {
        Type t = tuple.GetType();
        if (t.IsGenericType && t.GetGenericTypeDefinition().FullName.StartsWith("System.Tuple"))
        {
            for (int i = 1;; ++i)
            {
                string property = "Item" + i;
                var prop = t.GetProperty(property);
                if (prop == null)
                    yield break;
                yield return prop.GetValue(tuple);
            }
        }
    }

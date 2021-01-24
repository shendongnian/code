    public static void IterateTupleMemberTypes<T>() where T : ITuple
    {
        var tupleGenericArguments = typeof(T).GetGenericArguments();
        for (var i = 0; i < tupleGenericArguments.Length; ++i)
        {
            Console.WriteLine($"Item{i} Type: {tupleGenericArguments[i].Name}");
        }
    }

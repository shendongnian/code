    public static void GetProps<T>(T obj)
    {
        var result = typeof(T).GetProperties()                  
            .Select(x => Tuple.Create(x.Name, x.GetValue(obj)))
            .Where(x => x.Item2 != null)
            .ToList();
    }

    public static void GetProps<T>(T obj)
    {
        var result = typeof(T).GetProperties()
            .Select(x => new { property = x.Name, value = x.GetValue(obj) })
            .Where(x => x.value != null)
            .ToList();
    }

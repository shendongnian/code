    public static void CopyValues<T>(T source, T destination)
    {
        var props = typeof(T).GetProperties();
        foreach(var prop in props)
        {
            var value = prop.GetValue(source);
            prop.SetValue(destination, value);
        }
    }

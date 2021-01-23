    public static T Merge<T>(T master, T other) where T : new()
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.CanRead && p.CanWrite && !p.GetIndexParameters().Any());
        T result = new T();
        foreach (var prop in properties)
        {
            object value = prop.GetValue(master) ?? prop.GetValue(other);
            prop.SetValue(result, value);
        }
        return result;
    }

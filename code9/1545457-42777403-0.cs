    static void ReflectionMerge<T>(T source, T target)
        where T: class
    {
        var properties = typeof(T).
            GetProperties().
            Where(x => x.CanRead && x.CanWrite);
    
        foreach(var property in properties)
        {
            var sourceValue = property.GetValue(source);
            property.SetValue(target, sourceValue);
        }
    }

    public static Func<Test<T>, T> CreateDelegate<T>(PropertyInfo info)
    {
        Type type = info.ReflectedType;
    
        PropertyInfo genericProperty = type.MakeGenericType(typeof(T)).GetProperty(info.Name);
    
        return (source) => (T)genericProperty.GetValue(source);
    }

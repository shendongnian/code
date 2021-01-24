    public static Func<Test<T>, T> CreateGetter<T>(PropertyInfo info)
    {
        Type type = info.ReflectedType;
    
        PropertyInfo genericProperty = type.MakeGenericType(typeof(T)).GetProperty(info.Name);
    
        return (source) => (T)genericProperty.GetValue(source);
    }

    public static Func<Test<T>, T> GetGenericPropertyDelegate<T>(string propertyName)
    {
        PropertyInfo genericProperty = typeof(Test<>).MakeGenericType(typeof(T)).GetProperty(propertyName);
    
        return (source) => (T)genericProperty.GetValue(source);
    }

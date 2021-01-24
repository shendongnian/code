    public static Func<Test<T>, T> GetGenericItemDelegate<T>()
    {
        PropertyInfo genericProperty = typeof(Test<>).MakeGenericType(typeof(T)).GetProperty("Item");
    
        return (source) => (T)genericProperty.GetValue(source);
    }

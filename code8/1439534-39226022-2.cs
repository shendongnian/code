    public static bool IsCovariantIEnumerable(Type T1, Type T2)
    {
        Type enumerable1 = typeof(IEnumerable<>).MakeGenericType(T1);
        Type enumerable2 = typeof(IEnumerable<>).MakeGenericType(T2);
        return enumerable1.IsAssignableFrom(enumerable2);
    }

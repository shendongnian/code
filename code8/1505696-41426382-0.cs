    static bool IsNullable<T>(T obj)
    {
        // ...
        if (!type.IsValueType) return true; // ref-type
        if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
    }

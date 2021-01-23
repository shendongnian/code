    public static T ReplaceDbNullWithDefault<T>(this object value)
    {
        if (value == System.DBNull.Value || object.ReferenceEquals(default(T), value))
            return default(T);
        if (value is T)
            return (T) value;
        if (value is IConvertible)
            return (T) ((IConvertible) value).ToType(typeof(T), null);
        throw new InvalidCastException($"Cannot convert {value.GetType()} to {typeof(T)}.");
    }

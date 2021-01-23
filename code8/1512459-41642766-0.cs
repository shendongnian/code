    public static Nullable<T> DbNullOrValue<T>(this string input) where T : struct, IConvertible
    {
        if (!string.IsNullOrEmpty(input))
            return (T)Convert.ChangeType(input, typeof(T));
        
        return null;
    }

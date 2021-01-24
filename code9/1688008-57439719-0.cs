    public static bool TryConvert<T>(object input, out T output)
    {
        if (input is T result)
        {
            output = result;
            return true;
        }
        output = default(T);
        // Check if input is null and T is a nullable type.
        return input == null && System.Nullable.GetUnderlyingType(typeof(T)) != null;
    }

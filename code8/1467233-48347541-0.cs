     public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.GetType().GetProperties(
                BindingFlags.DeclaredOnly |
                BindingFlags.Public |
                BindingFlags.Instance).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null) ?? string.Empty
            );
        }
        public static bool EqualsByValue(this object source, object destination)
        {
            return source.ToDictionary().Except(destination.ToDictionary()).Count() == 0;
        }
    originalObj.EqualsByValue(messageBody); // will compare values.

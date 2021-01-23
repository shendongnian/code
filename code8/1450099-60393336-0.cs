    public static class Requirements
    {
        public static T NotNull<T>(this T value, string parameterName, string message)
            where T : class =>
            value ?? throw new ArgumentNullException(parameterName, message);
        public static T NotNull<T>(this T value, string parameterName)
            where T : class =>
            value ?? throw new ArgumentNullException(parameterName);
    }

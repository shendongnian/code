    public static class Extension
    {
        public static object GetValue(this IReadableVar v)
        {
            return v.Value;
        }
        public static void SetValue(this IWritableVar v, object value)
        {
            v.Value = value;
        }
    }

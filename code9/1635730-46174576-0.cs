    public static class StringExtensions
    {
        public static string Coalesce(this string value, string @default)
        {
            return string.IsNullOrEmpty(value)
                ? value
                : @default;
        }
    }

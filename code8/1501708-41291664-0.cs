    public static class MyExtensions
    {
        public static string Join(this IEnumerable<string> enumeration, string separator)
           => string.Join(separator, enumeration);
    }

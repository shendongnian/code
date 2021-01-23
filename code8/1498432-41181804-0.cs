    public static class Extensions
    {
        public static decimal TestSum<T>(this IEnumerable<T> source, Func<T, decimal> selector)
        {
            return 0;
        }
        public static int TestSum<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            return 0;
        }
        public static int? TestSum<T>(this IEnumerable<T> source, Func<T, int?> selector)
        {
            return 0;
        }
    }
    CS0121	The call is ambiguous between the following methods or properties: 
    'Extensions.TestSum<T>(IEnumerable<T>, Func<T, decimal>)' and 
    'Extensions.TestSum<T>(IEnumerable<T>, Func<T, int>)'

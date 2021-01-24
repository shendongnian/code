    static class StringExtensions
    {
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
    class Program
    {
        static void Main()
        {
            string s = /* some string or null reference */
            bool hasValue = s.HasValue();
        }
    }

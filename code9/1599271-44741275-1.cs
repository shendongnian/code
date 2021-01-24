    static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
    class Program
    {
        static void Main()
        {
            string s = /* some string or null reference */
            bool isEmpty = s.IsNullOrEmpty();
        }
    }

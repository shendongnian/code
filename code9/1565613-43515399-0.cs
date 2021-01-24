    namespace ConsoleApp1
    {
        public static class Int32Extensions
        {
            public static bool IsGreaterThanOrEqualTo(this int x, int y)
            {
                return x >= y;
            }
        }
    
        internal static class Program
        {
            internal static void Main()
            {
                if (17.IsGreaterThanOrEqualTo(42))
                {
                    // ...
                }
            }
        }
    }

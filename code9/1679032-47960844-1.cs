    namespace MyNamepace
    {
        public static class Program
        {
            public static void Main(String[] args)
            {
                Boolean b = true;
                Boolean b_rev = b.Reverse();
                Console.WriteLine(b); // True
                Console.WriteLine(b_rev); // False
                
                Int32 i = -20;
                Int32 i_rev = i.Reverse();
                Console.WriteLine(i); // -20
                Console.WriteLine(i_rev); // 20
            }
        }
        
        public static class ExtensionMethods
        {
            public static Boolean Reverse(this Boolean value)
            {
                return !value;
            }
            
            public static Int32 Reverse(this Int32 value)
            {
                return -value;
            }
        }
    }

        public enum Letter
        {
            A,
            B,
            C
        }
        public enum Number
        {
            One,
            Two,
            Three
        }
        public static void Main(string[] args)
        {
            int val1 = 2;
            Type type1 = typeof(Letter);
            int val2 = 0;
            Type type2 = typeof(Number);
            var result1 = Enum.GetName(type1, val1);
            var result2 = Enum.GetName(type2, val2);
            Console.WriteLine("result1 {0}", result1);
            Console.WriteLine("result2 {0}", result2);
            Console.ReadKey();
        }

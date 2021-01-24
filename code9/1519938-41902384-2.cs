        public static string StringFromEnum(Enum e)
        {
            string result = null;
            if (e.GetType() == typeof(Letter))
            {
                result =  ((Letter)e).ToString();
            }
            else if (e.GetType() == typeof(Number))
            {
                result = ((Number)e).ToString();
            }
            return result;
        }
        public static void Main(string[] args)
        {
            int val1 = 2;
            Type type1 = typeof(Letter);
            int val2 = 0;
            Type type2 = typeof(Number);
            var result1 = GetEnum(type1, val1);
            var result2 = GetEnum(type2, val2);
            Console.WriteLine("result1 {0}", StringFromEnum(result1));
            Console.WriteLine("result2 {0}", StringFromEnum(result2));
            Console.ReadKey();
        }

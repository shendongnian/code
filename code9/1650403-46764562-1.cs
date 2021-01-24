        public static void Func(int i)
        {
            i++;
            Console.WriteLine("int a = {0}", i);
        }
        public static void Func(ref int i)
        {
            i++;
            Console.WriteLine("ref int a = {0}", i);
        }
        static void Main(string[] args)
        {
            int a = 9;
            Func(ref a);
            // Func(a);
            Console.WriteLine("a = {0}", a);
            Console.Read();
        }

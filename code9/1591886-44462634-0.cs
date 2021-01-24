    namespace Calculator
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                 divide(2,3);
            }
            public static void add(int num01, int num02)
            {
                Console.WriteLine("The result is " + (num01 + num02));
                Console.ReadKey();
            }
            public static void multiply(int num01, int num02)
            {
                Console.WriteLine("The result is " + (num01 * num02));
                Console.ReadKey();
            }
            public static void divide(double num01, double num02)
            {
                Console.WriteLine("The result is " + (num01 / num02));
                Console.ReadKey();
            }
            public static void subtract(int num01, int num02)
            {
                Console.WriteLine("The result is " + (num01 - num02));
                Console.ReadKey();
            }
        }
    }

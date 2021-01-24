    class Program
    {
        private static string cats;
    
        static void Main(string[] args)
        {
            cats = "1000 Cats";
            test_method();
            cats = "6 Cats";
            test_method();
        }
    
        static void test_method()
        {
            Console.Write(cats);
        }
    }

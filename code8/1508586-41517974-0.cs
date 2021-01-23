    static void Main(string[] args)
        {
            try
            {
                Method1();
                Method2();
                Method3();
                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something wrong happened!");
            }
            Console.ReadLine();
        }
        private static void Method1()
        {
            Console.WriteLine("Here is one");
        }
        private static void Method2()
        {
            Console.WriteLine("Here is two");
            string foo = null;
            foo.ToUpper();
        }
        private static void Method3()
        {
            Console.WriteLine("Here is three");
        }

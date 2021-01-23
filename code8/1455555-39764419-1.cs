      class Program
    {
        static void Main(string[] args)
        {
            var testObject = new TestClass(5);
            if ((testObject.Length == 5) && (testObject.Length == 11))
            {
                Console.WriteLine("TRUE");
            }
            else
            {
                Console.WriteLine("FALSE");
            }
            Console.Read();
        }
    }

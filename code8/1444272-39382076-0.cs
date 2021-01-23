        class Program
        {
            static void Main(string[] args)
            {
                SomeClass.finalMethod(SomeClass.ifPossible(SomeClass.functionOne(), SomeClass.functionTwo()));
                Console.ReadLine();
            }
    }
        class SomeClass
    {
        internal static int functionOne()
        {
            int number;
            Console.WriteLine("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            return number;
        }
    
        internal static int functionTwo()
        {
            int number;
            Console.WriteLine("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            return number;
        }
    
        internal static bool ifPossible(int x, int y)
        {
            if (x < y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        internal static void finalMethod(bool x)
        {
            if (x)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Fail");
            }
        }
    }

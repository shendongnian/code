    namespace Testing
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(factorial_Recursion(5));
                Console.WriteLine("press any Key");
                Console.ReadLine();
            }
            public static double factorial_Recursion(int number)
            {
                if (number == 1)
                    return 1;
                else
                    return number*factorial_Recursion(number - 1);
            }

    public class Factorial
    {
        public static double factorial_Recursion(int number)
        {
            if (number == 1)
                return 1;
            else
                return number * factorial_Recursion(number - 1);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial.factorial_Recursion(10));
        }
    }

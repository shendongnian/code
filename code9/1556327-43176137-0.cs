    static void Main(string[] args)
            {
    
                Console.Write("Enter the first number\t");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number\t");
                int number2 = Convert.ToInt32(Console.ReadLine());
    
                sum(number1, number2);
                difference(number1, number2);
                multiplies(number1, number2);
            }
    
            public static void sum(int number1, int number2)
            {
                Console.WriteLine(string.Format("Sum is: {0}", number1 + number2));
            }
    
            public static void difference(int number1, int number2)
            {
                Console.WriteLine(string.Format("difference is: {0}", number1 - number2));
            }
            public static void multiplies(int number1, int number2)
            {
                Console.WriteLine(string.Format("multiplies : {0}", number1 * number2));
            }

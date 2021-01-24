    static void Main(string[] args)
            {
    
                Console.Write("Enter the first number\t");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number\t");
                int number2 = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine(sum(number1, number2));
                Console.WriteLine(difference(number1, number2));
                Console.WriteLine(multiplies(number1, number2));
    
            }
    
            public static int sum(int number1, int number2)
            {
                Console.WriteLine("Sum is:");
                return number1 + number2;
            }
    
            public static int difference(int number1, int number2)
            {
                Console.WriteLine("difference is:");
                return number1 - number2;
            }
            public static int multiplies(int number1, int number2)
            {
                Console.WriteLine("multiplies:");
                return number1 * number2;
            }

     static void Main(string[] args)
            {
                Console.Write("Enter the first number\t");
                int number1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the second number\t");
                int number2 = Convert.ToInt32(Console.ReadLine());
                int result1=sum(number1, number2);
                Console.WriteLine(result1);
                int result2=difference(number1, number2);
                Console.WriteLine(result2);
                int result3=multiplies(number1, number2);
                Console.WriteLine(result3);
                Console.ReadLine();
            }
            public  static int sum(int number1, int number2)
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
                return number1*number2;
            }

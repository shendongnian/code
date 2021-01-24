    class Program
    {
        public static void Main(string[] args)
        {
            string input = String.Empty;
            int x = 0, y = 0;
      
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter first number");
                     x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Would you like to\n1. Add\n2. Multiply\n3. Divide");
                    input = Console.ReadLine();
                    Console.WriteLine("Please enter a second number");
                    y = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                switch (input)
                {
                    case "1":
                        Console.WriteLine($"{x} + {y} = " + add(x, y));
                        break;
                    case "2":
                        //TODO implement multiply case
                        break;
                    case "3":
                        //TODO implement divide case
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                            break;
                }
            }
        }
        public static int add(int x, int y) => x + y;
    }

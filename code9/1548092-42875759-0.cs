    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter first number");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Would you like to\n1. Add\n2. Multiply\n3. Divide");
                string input = Console.ReadLine();
                Console.WriteLine("Please enter a second number");
                int y = int.Parse(Console.ReadLine());
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
                }
            }
        }
        public static int add(int x, int y) => x + y;
    }

     static void Main(string[] args)
        {
            int number1, number2;
            Console.WriteLine("Enter three numbers.");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            if ((Math.Abs(x - y) < Math.Abs(y - z)) && (Math.Abs(x - y) < (Math.Abs(x - z))
            {
                number1 = x;
                number2 = y;
            }

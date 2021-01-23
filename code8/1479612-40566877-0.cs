    class Program
    {
        static void Main(string[] args)
        {
            var stringValue = Console.ReadLine();
            int number;
            if (int.TryParse(stringValue, out number))
                Console.WriteLine($"The double of {number} is {number * 2}");
            else
                Console.WriteLine($"Wrong input! '{stringValue}' is not an integer!");
            Console.Read();
        }
    }

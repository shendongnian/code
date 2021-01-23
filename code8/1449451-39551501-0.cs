    {
    Console.WriteLine("Enter the temperature in Fahrenheit: ");
            int fahrenheit;
            int celsius;
            do
            {
                fahrenheit = int.Parse(Console.ReadLine());
                celsius = FahrToCels(fahrenheit);
                if (celsius < 73)
                {
                    Console.WriteLine(celsius);
                    Console.WriteLine("It's too cold, raise the temperature.");
                }

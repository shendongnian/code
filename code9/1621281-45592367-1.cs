    static double income_input()
    {
        while (true)
        {
            Console.WriteLine("What is your income?:");
            if (double.TryParse(Console.ReadLine(), out double income) && income > 0)
                return income;
            Console.WriteLine("Invalid input. Please enter a valid number greater than zero.");
        }
    }

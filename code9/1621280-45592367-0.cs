    static double income_input()
    {
        double income = double.NaN;
        while (true)
        {
            Console.WriteLine("What is your income?:");
            if (double.TryParse(Console.ReadLine(), out income) && income > 0)
                return income;
            Console.WriteLine("Invalid input. Please enter a valid number greater than zero.");
        }
    }

    private static void Main()
    {
        // Get a list of years from the user
        Console.Write("Enter some years separated by commas: ");
        var input = Console.ReadLine();
        // Split the user input on the comma character, creating an array of years
        var years = input.Split(',');
        foreach (var year in years)
        {
            bool isLeapYear = IsLeapYear(int.Parse(year));
            if (isLeapYear)
            {
                Console.WriteLine("{0} is a leap year", year);
            }
            else
            {
                Console.WriteLine("{0} is not a leap year", year);
            }
        }
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

    private static void Main()
    {
        // In this loop, ask for a year and tell them the answer
        while (true)
        {
            int input = GetIntFromUser("Enter a year to check: ");
            string verb = IsLeapYear(input) ? "is" : "is not";
            Console.WriteLine($"{input} {verb} a leap year.\n");
        }
    }
    public static int GetIntFromUser(string prompt)
    {
        int input;
        // Show the prompt and keep looping until the input is a valid integer
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }
    public static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

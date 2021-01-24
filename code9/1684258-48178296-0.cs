    private static TimeSpan GetTimeFromUser(string prompt)
    {
        Console.Write(prompt);
        TimeSpan result;
            
        while (!TimeSpan.TryParse(Console.ReadLine() + ":00", out result))
        {
            Console.WriteLine("Please use format hh:mm for the time.");
            Console.Write(prompt);
        }
        return result;
    }
    private static int GetIntFromUser(string prompt)
    {
        Console.Write(prompt);
        int result;
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Please enter a valid integer.");
            Console.Write(prompt);
        }
        return result;
    }

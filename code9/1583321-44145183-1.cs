    private static void Main()
    {
        // DateTime.Now includes a non-zero time (except at midnight)
        Console.WriteLine(DateTime.Now.GetCustomFormatString());
        // A new DateTime has a zero time value
        Console.WriteLine(new DateTime().GetCustomFormatString());
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

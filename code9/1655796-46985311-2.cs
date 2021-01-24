    static void Main(string[] args)
    {
        var today = DateTime.Now;
        var later = today.AddMonths(3.5);
        Console.WriteLine($"Today: {today}");
        Console.WriteLine($"Today plus 3.5 months: {later}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

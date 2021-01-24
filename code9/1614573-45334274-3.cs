    static void Main(string[] args)
    {
    
        Console.WriteLine(GetPinForDate(new DateTime(2017, 7, 26)));
        Console.WriteLine(GetPinForDate(new DateTime(2017, 7, 27)));
        Console.WriteLine(GetPinForDate(new DateTime(2017, 7, 28)));
        Console.WriteLine(GetPinForDate(new DateTime(2017, 7, 29)));
    
        Console.ReadLine();
    }
    
    static string GetPinForDate(DateTime targetDate)
    {
        var days = Math.Floor((targetDate - new DateTime(2000, 1, 1)).TotalDays);
        return (days.GetHashCode() << 8).ToString().Substring(6);
    }

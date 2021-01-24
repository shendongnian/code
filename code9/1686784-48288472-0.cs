    static void Main(string[] args)
    {
        DateTime datetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 5, 0, 0); //5AM tomorrow
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        DateTime pstTime = TimeZoneInfo.ConvertTimeToUtc(datetime, pstZone);
        Console.WriteLine(pstTime);
        Console.ReadKey();
    }

    public static void Main(string[] args)
    {
        TimeSpan span1 = Convert("00.05.415");
        TimeSpan span2 = Convert("00.07.415");
        TimeSpan result = span1 + span2;
            
        Console.WriteLine(result);
        Console.ReadKey();
    }
    public static TimeSpan Convert(string span)
    {
        return TimeSpan.ParseExact(span, @"mm\.ss\.fff", CultureInfo.InvariantCulture);
    }

    static void Main(string[] args)
    {
        int year = DateTime.Now.Year;
        DateTime startDate = FirstMonday(year);
        while (startDate.Year == year)
        {
            Console.WriteLine(startDate);
            startDate = startDate.AddDays(7);
        }
    }

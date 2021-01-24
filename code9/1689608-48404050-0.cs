    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            LocalDate start = new LocalDate(2017, 10, 16);
            LocalDate end = new LocalDate(2018, 1, 15);
            Period period = Period.Between(start, end.PlusDays(1));
            
            Console.WriteLine(
                $"{period.Years} years, {period.Months} months, {period.Days} days");
        }
    }

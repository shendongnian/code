    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            ShowDate(2017, 1, 1);
            ShowDate(2017, 3, 27);
            ShowDate(2017, 9, 7);
        }
        
        private static void ShowDate(int year, int month, int day)
        {
            var date = new LocalDate(year, month, day);
            var result = GetWeekYearAndWeek(date);
            Console.WriteLine($"{date:uuuu-MM-dd} => {result}");
        }
        
        private static (int weekYear, int week) GetWeekYearAndWeek(LocalDate date)
        {
            // Initial guess...
            int weekYear = date.Year;
            var startOfWeekYear = GetStartOfWeekYear(weekYear);
            if (date < startOfWeekYear)
            {
                weekYear--;
                startOfWeekYear = GetStartOfWeekYear(weekYear);
            }
            
            int days = Period.Between(startOfWeekYear, date, PeriodUnits.Days).Days;
            int week = (days / 7) + 1;
    
            return (weekYear, week);
        }
    
        private const IsoDayOfWeek StartOfWeek = IsoDayOfWeek.Monday;
        
        private static LocalDate GetStartOfWeekYear(int weekYear) =>
            new LocalDate(weekYear, 4, 1).With(DateAdjusters.PreviousOrSame(StartOfWeek));
    }

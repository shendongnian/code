    using System;
    
    class Program
    {
        static void Main (string[] args)
        {
            ShowWeeks(new DateTime(2016, 9, 17), new DateTime(2016, 9, 26));
            ShowWeeks(new DateTime(2016, 9, 17), new DateTime(2016, 9, 25));
            ShowWeeks(new DateTime(2016, 9, 19), new DateTime(2016, 9, 26));
            ShowWeeks(new DateTime(2016, 9, 12), new DateTime(2016, 9, 25));
        }
        
        static void ShowWeeks(DateTime start, DateTime end)
        {
            int weeks = GetWeeks(start, end);
            Console.WriteLine($"{start:d} {end:d} {weeks}");
        }
        
        // Always uses Monday-to-Sunday weeks
        public static DateTime GetStartOfWeek(DateTime input)
        {
            // Using +6 here leaves Monday as 0, Tuesday as 1 etc.
            int dayOfWeek = (((int) input.DayOfWeek) + 6) % 7;
            return input.Date.AddDays(-dayOfWeek);
        }
        
        public static int GetWeeks(DateTime start, DateTime end)
        {
            start = GetStartOfWeek(start);
            end = GetStartOfWeek(end);
            int days = (int) (end - start).TotalDays;
            return (days / 7) + 1; // Adding 1 to be inclusive
        }
    }

    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                foreach (var saturday in FilteredSaturdays(DateTime.Now, new DateTime(2017, 12, 31)))
                {
                    Console.WriteLine(saturday);
                }
            }
            public static IEnumerable<DateTime> FilteredSaturdays(DateTime start, DateTime end)
            {
                DateTime startMonth = new DateTime(start.Year, start.Month, 1);
                DateTime endMonth = new DateTime(end.Year, end.Month, 1).AddMonths(1);
                for (DateTime month = startMonth; month < endMonth; month = month.AddMonths(1))
                {
                    // Work out date of last saturday in the month.
                    DateTime lastDayOfMonth = month.AddMonths(1).AddDays(-1);
                    DateTime lastSaturdayOfMonth = lastDayOfMonth.AddDays(-(((int)lastDayOfMonth.DayOfWeek+1)%7));
                    // Return saturday 2 weeks before last saturday of month, and last saturday of month.
                    yield return lastSaturdayOfMonth.AddDays(-14);
                    yield return lastSaturdayOfMonth;
                }
            }
        }
    }

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
                    // Work out date of first saturday.
                    DateTime saturday = month.AddDays(6 - (int)month.DayOfWeek);
                    // If the first saturday occurs on or before the 3rd then the second saturday
                    // will occur on or before the 9th, so skip a week.
                    if (saturday.Day <= 3)
                        saturday = saturday.AddDays(7);
                    // Now return the appropriate saturdays.
                    yield return saturday.AddDays(7);
                    yield return saturday.AddDays(21);
                }
            }
        }
    }

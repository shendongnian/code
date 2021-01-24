    using System;
    using System.Collections.Generic;
    namespace ConsoleApp3
    {
    class Program
    {
        static void Main(string[] args)
        {
            var validDates = new List<DateTime>();
            getDates(new DateTime(17,7,20), new DateTime(17,10,20),new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday },out validDates, 3);
            validDates.ForEach(date => Console.WriteLine(date.ToString("dd/MM")));
            Console.ReadKey();
        }
        static void getDates(DateTime startDate, DateTime endDate, List<DayOfWeek> daysOfTheWeek, out List<DateTime> validDates, int pattern)
        {
            validDates = new List<DateTime>();
            for (var i = startDate; i <= endDate; i=i.AddDays(7*(pattern-1)))
            {
                for (int j = 0; j < 7; j++)
                {
                    if (daysOfTheWeek.Contains(i.DayOfWeek))
                    {
                        validDates.Add(i);
                    }
                    i=i.AddDays(1);
                    if (i >= endDate || i.DayOfWeek == DayOfWeek.Monday) //assuming you were counting weeks starting on Monday
                        break;
                }
            }
            
        }
    }
    }

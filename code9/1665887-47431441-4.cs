    using System;
    using MoreLinq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var dates = new []
                {
                    new DateTime(2017, 11, 9, 8, 2, 9),
                    new DateTime(2017, 11, 9, 5, 9, 23),
                    new DateTime(2017, 11, 9, 15, 22, 51),
                    new DateTime(2017, 11, 9, 17, 9, 23),
                    new DateTime(2017, 11, 10, 11, 23, 04),
                    new DateTime(2017, 11, 10, 16, 19, 57),
                    new DateTime(2017, 11, 14, 10, 11, 11),
                    new DateTime(2017, 11, 14, 18, 30, 30)
                };
                var distinctByDate = dates.OrderBy(date => date).DistinctBy(date => date.Date);
                foreach (var date in distinctByDate)
                    Console.WriteLine(date);
            }
        }
    }

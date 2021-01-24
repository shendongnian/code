    public class Program
    {
        public static void Main(string[] args)
        {
            var dates = new List<DateTime>();
            dates.Add(new DateTime(2017, 5, 15));
            dates.Add(new DateTime(2017, 5, 3));
            dates.Add(new DateTime(2017, 4, 7));
            dates.Add(new DateTime(2017, 4, 4));
            dates.Add(new DateTime(2017, 4, 1));
            dates.Add(new DateTime(2017, 3, 31));
            dates.Add(new DateTime(2017, 3, 22));
            dates.Add(new DateTime(2017, 3, 5));
            dates.Add(new DateTime(2017, 3, 2));
            
            var firstOfEachMonths = dates
                // Group the dates by their month.
                .GroupBy(date => date.Month)
                // Project each group into the earliest day.
                .Select(group => group
                        .OrderBy(date => date.Day)
                        .First())
                .ToList();
            /* 
             * Output:
             * 03.05.2017 00:00:00
             * 01.04.2017 00:00:00
             * 02.03.2017 00:00:00
             */
            foreach (var firstOfEachMonth in firstOfEachMonths) 
            {
                Console.Out.WriteLine(firstOfEachMonth);
            }
        }
    }

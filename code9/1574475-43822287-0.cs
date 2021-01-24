    class Program
    {
        static void Main(string[] args)
        {
            foreach(var week in 2017.GenerateWeekSequence())
            {
                Console.WriteLine($"Week ({week.WeekNumber}. First day={week.FirstDayOfWeek.ToString()}, Last day={week.LastDayOfWeek.ToString()}");
            }
        }
    }
    public static class WeekExtensions
    {
        private static CultureInfo ThreadCulture => Thread.CurrentThread.CurrentCulture;
        public class Info
        {
            public Info(DateTime firstDayOfWeek) { FirstDayOfWeek = firstDayOfWeek; }
            public int WeekNumber => ThreadCulture.Calendar.GetWeekOfYear(
                FirstDayOfWeek, CalendarWeekRule.FirstDay, ThreadCulture.DateTimeFormat.FirstDayOfWeek);
            public DateTime FirstDayOfWeek { get; }
            public DateTime LastDayOfWeek => FirstDayOfWeek.AddDays(6);
        }
        public static IEnumerable<Info> GenerateWeekSequence(this int year)
        {
            var runner = new DateTime(year, 1, 1);
            // Move back to the first day of week (even if it's in the previous year)
            while (runner.DayOfWeek != ThreadCulture.DateTimeFormat.FirstDayOfWeek)
            {
                runner = runner.AddDays(-1);
            }
            // Now, jump dates one week at a time
            while (runner.Year <= year)
            {
                yield return new Info(runner);
                runner = runner.AddDays(7);  // Jump to first day of next week
            }
        }
    }

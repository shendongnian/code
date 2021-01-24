    class sample2
    {
        internal static void Test()
        {
            var sampleTarget = new DateTime(2016, 4, 1);
            var dayInYearForTarget = DayInYear(sampleTarget);
            Console.WriteLine("Date: {0} => {1}", sampleTarget, dayInYearForTarget);
            Console.ReadKey();
        }
        private static double DayInYear(DateTime target)
        {
            var date = target.Date;
            var year = date.Year;
            return date.Subtract(new DateTime(year, 1, 1)).TotalDays + 1;
        }
    }

        public static void Main(string[] args)
        {
            Console.WriteLine(CalculateWeeks(new DateTime(2016, 9, 17), new DateTime(2016, 9, 26)));
            Console.WriteLine(CalculateWeeks(new DateTime(2016, 9, 17), new DateTime(2016, 9, 25)));
            Console.WriteLine(CalculateWeeks(new DateTime(2016, 9, 19), new DateTime(2016, 9, 26)));
            Console.WriteLine(CalculateWeeks(new DateTime(2016, 9, 12), new DateTime(2016, 9, 25)));
        }
        public static double CalculateWeeks(DateTime from, DateTime to)
        {
            if (to.DayOfWeek != DayOfWeek.Sunday)
                to = to.Add(new TimeSpan(7- (int) to.DayOfWeek, 0, 0, 0)).Date;
            return Math.Ceiling((to - from.Subtract(new TimeSpan((int)from.DayOfWeek - 1, 0, 0, 0)).Date).TotalDays / 7);
        }

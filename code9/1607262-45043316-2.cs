        public List<DateTime> GetDatesInMonthByWeekday(DateTime date, DayOfWeek dayOfWeek) {
            // We know the first of the month falls on, well, the first.
            var first = new DateTime(date.Year, date.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            // Find the first day of the week that matches the requested day of week.
            if (first.DayOfWeek != dayOfWeek) {
                first = first.AddDays(((((int)dayOfWeek - (int)first.DayOfWeek) + 7) % 7));
            }
            // A weekday in a 31 day month will only occur five times if it is one of the first three weekdays.
            // A weekday in a 30 day month will only occur five times if it is one of the first two weekdays.
            // A weekday in February will only occur five times if it is the first weekday and it is a leap year.
            // Incidentally, this means that if we subtract the day of the first occurrence of our weekday from the 
            // days in month, then if that results in an integer greater than 27, there will be 5 occurrences.
            int maxOccurrences = (daysInMonth - first.Day) > 27 ? 5 : 4;
            var list = new List<DateTime>(maxOccurrences);
            for (int i = 0; i < maxOccurrences; i++) {
                list.Add(new DateTime(first.Year, first.Month, (first.Day + (7 * i))));
            }
            return list;
        }

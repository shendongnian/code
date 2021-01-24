        private static List<DateTime> GetDaysOfWeek(DateTime date, DayOfWeek dayOfWeek)
        {            
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var i = 1;
            List<DateTime> result = new List<DateTime>(5);
            do
            {
                var testDate = new DateTime(date.Year, date.Month, i);
                if (testDate.DayOfWeek == dayOfWeek)
                {
                    result.Add(testDate);
                    i += 7;
                }
                else
                {
                    i++;
                }
            } while (i <= daysInMonth);
            return result;
        }

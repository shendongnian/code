    public class WeekdaysByMonth
    {
        public IEnumerable<DateTime> GetWeekdaysForMonth(DateTime month, DayOfWeek weekDay)
        {
            return GetDaysInMonth(month).Where(day => day.DayOfWeek == weekDay);
        }
        private IEnumerable<DateTime> GetDaysInMonth(DateTime date)
        {
            var dateLoop = new DateTime(date.Year,date.Month,1);
            while (dateLoop.Month == date.Month)
            {
                yield return dateLoop;
                dateLoop = dateLoop.AddDays(1);
            }
        }
    }

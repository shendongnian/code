    public static class DateTimeExtensions
    {
        public static DateTime EndOfWeek(this DateTime date) => 
           date.AddDays(date.DayOfWeek == DayOfWeek.Sunday ? 0 : 7 - (int)date.DayOfWeek).Date;
    }

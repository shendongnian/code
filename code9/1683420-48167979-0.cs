    public static class DateTimeExtension
    {
        public static string ToReverseShortDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string ToGermanDateString(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }

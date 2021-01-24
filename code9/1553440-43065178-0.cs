    public static class DateTimeExtensions
    {
        public static int NumberOfSecondsUntil(this string start, string end)
        {
            return (int)(DateTime.Parse(end) - DateTime.Parse(start)).TotalSeconds;
        }
    }

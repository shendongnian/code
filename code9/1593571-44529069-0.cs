    using System;
    public static class DateTimeUtilities
    {
        public static bool TryParse(int year, int month, int day, out DateTime result)
        {
            return DateTime.TryParse(
                string.Format("{0}/{1}/{2}", year, month, day), out result);
        }
    }

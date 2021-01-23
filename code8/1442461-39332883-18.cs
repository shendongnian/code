    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    namespace LambdaSample.Extensions
    {
        public static class StringExtensions
        {
            private static List<string> GetValidDateTimeFormats()
            {
                var dateFormats = new[]
                {
                    "dd.MM.yyyy",
                    "yyyy-MM-dd",
                    "yyyyMMdd",
                }.ToList();
                var timeFormats = new[]
                {
                    "HH:mm:ss.fff",
                    "HH:mm:ss",
                    "HH:mm",
                }.ToList();
                var result = (from dateFormat in dateFormats
                              from timeFormat in timeFormats
                              select $"{dateFormat} {timeFormat}").ToList();
                return result;
            }
            public static bool ParseDateTimeEx(this string @this, CultureInfo culture, out DateTime dateTime)
            {
                if (culture == null)
                {
                    culture = CultureInfo.InvariantCulture;
                }
                if (DateTime.TryParse(@this, culture, DateTimeStyles.None, out dateTime))
                    return true;
                var dateTimeFormats = GetValidDateTimeFormats();
                if (DateTime.TryParseExact(@this, dateTimeFormats.ToArray(), culture, DateTimeStyles.None, out dateTime))
                    return true;
                return false;
            }
        }
    }

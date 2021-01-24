    using System;
    using NodaTime;
    
    namespace YourApp.Extensions
    {
        public static class NodaTimeExtensions
        {
            public static LocalDate ToNodaLocalDate(this DateTime dateTime)
            {
                return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
            }
    
            public static LocalTime ToNodaLocalTime(this DateTime dateTime)
            {
                return new LocalTime(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
            }
        }
    }

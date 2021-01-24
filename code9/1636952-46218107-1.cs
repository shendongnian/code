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
        }
    }

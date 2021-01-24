    using System;
    
    using NodaTime;
    using NodaTime.TimeZones;
    
    namespace TimeZoneExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Arizona without daylight saving time (TZ: America/Phoenix)
                var mstWithoutDstTz = TimeZoneInfo.FindSystemTimeZoneById("US Mountain Standard Time");
    
                // Arizona with daylight saving time (TZ: America/Shiprock)
                var mstWithDstTz = TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time");
    
                // NodaTime BclDateTimeZone for Arizona without daylight saving time
                var mstWithoutDstNodaTz = BclDateTimeZone.FromTimeZoneInfo(mstWithoutDstTz);
    
                // NodaTime BclDateTimeZone for Arizona with daylight saving time
                var mstWithDstNodaTz = BclDateTimeZone.FromTimeZoneInfo(mstWithDstTz);
                
                // January 1, 2017, 15:00, local winter date
                var localWinterDate = new LocalDateTime(2017, 01, 01, 15, 00);
    
                // NodaTime ZonedDateTime for Arizona without daylight saving time: January 1, 2017, 15:00
                var winterTimeWithoutDst = mstWithoutDstNodaTz.AtStrictly(localWinterDate);
    
                // NodaTime ZonedDateTime for Arizona with daylight saving time: January 1, 2017, 15:00
                var winterTimeWithDst = mstWithDstNodaTz.AtStrictly(localWinterDate);
    
                // Both time zones have the same time during winter
                Console.WriteLine($"Winter w/o DST: {winterTimeWithoutDst}"); // 2017-01-01T15:00:00 US Mountain Standard Time (-07)
                Console.WriteLine($"Winter w/ DST: {winterTimeWithDst}"); // 2017-01-01T15:00:00 Mountain Standard Time (-07)
    
                // add 180 days to get June 30, 2017
                var sixMonthsToSummer = Duration.FromTimeSpan(new TimeSpan(180, 0, 0, 0));
    
                // During summer, e.g. on June 30, Arizona without daylight saving time is 1 hour behind.
                Console.WriteLine($"Summer w/o DST: {winterTimeWithoutDst + sixMonthsToSummer}"); // 2017-06-30T15:00:00 US Mountain Standard Time (-07)
                Console.WriteLine($"Summer w/ DST: {winterTimeWithDst + sixMonthsToSummer}"); // 2017-06-30T16:00:00 Mountain Standard Time (-06)
            }
        }
    }

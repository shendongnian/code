    using System;
    using System.Globalization;
    
    using static System.FormattableString;
    
    class Program
    {
        static void Main()
        {        
            // Stay in winter
            Test("2017-01-22T15:00:00+01:00");
            // Skipped time during transition
            Test("2017-03-25T02:30:00+01:00");
            // Offset change to summer
            Test("2017-03-25T15:00:00+01:00");
            // Stay in summer
            Test("2017-06-22T15:00:00+02:00");
            // Ambiguous time during transition
            Test("2017-10-28T02:30:00+02:00");
            // Offset change back to winter
            Test("2017-10-28T15:00:00+02:00");
            // Stay in winter
            Test("2017-12-22T15:00:00+01:00");
        }
        
        static void Test(string startText)
        {
            var zone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var start = DateTimeOffset.ParseExact(
                startText, "yyyy-MM-dd'T'HH:mm:ssK", CultureInfo.InvariantCulture);
            try
            {
                var end = AddOneDay(start, zone);
                Console.WriteLine(Invariant($"{startText} => {end:yyyy-MM-dd'T'HH:mm:ssK}"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"{startText} => {e.Message}");
            }
        }
        
        static DateTimeOffset AddOneDay(DateTimeOffset start, TimeZoneInfo zone)
        {
            var newLocal = start.DateTime.AddDays(1);
            // TODO: Use a better exception type :)
            if (zone.IsAmbiguousTime(newLocal))
            {
                throw new Exception("Ambiguous");
            }
            if (zone.IsInvalidTime(newLocal))
            {
                throw new Exception("Skipped");
            }
            return new DateTimeOffset(newLocal, zone.GetUtcOffset(newLocal));
        }
            
    }

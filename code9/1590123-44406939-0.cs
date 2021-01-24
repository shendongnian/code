    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            string text = "2017060623:20:10";
            Console.WriteLine(GetZonedDateTimeUtcFromMarketDataString(text));
            
        }
        
        static readonly ZonedDateTimePattern ParsePattern =
            ZonedDateTimePattern.CreateWithInvariantCulture(
               "yyyyMMddHH:mm:ss",
               DateTimeZoneProviders.Tzdb); // Won't actually be used...
        
        static ZonedDateTime GetZonedDateTimeUtcFromMarketDataString(string dateTime)
            => ParsePattern.Parse(dateTime).Value;
    }

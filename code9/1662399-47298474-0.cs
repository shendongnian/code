    using System;
    using System.Linq;
    using NodaTime.TimeZones;
    
    namespace CodeTesting
    {
        class Program
        {
            static void Main()
            {
                string zoneName = "Europe/London";
    
                var tz = TzdbDateTimeZoneSource.Default.WindowsMapping.MapZones.FirstOrDefault(o => o.TzdbIds.Contains(zoneName)).WindowsId;
    
                Console.WriteLine(tz);
    
                Console.ReadKey();
            }
        }
    }

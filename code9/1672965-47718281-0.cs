    using System;
    using NodaTime.TimeZones;
    
    public class Test
    {
        static void Main()
        {
            var source = TzdbDateTimeZoneSource.Default;
            
            string windowsId = "Turks And Caicos Standard Time";
            
            var mapping = source.WindowsMapping.PrimaryMapping;
            if (mapping.TryGetValue(windowsId, out string tzdbId))
            {
                Console.WriteLine($"Mapped to {tzdbId}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }    
    }

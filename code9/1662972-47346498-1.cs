    using Newtonsoft.Json;
    using NodaTime;
    using NodaTime.Serialization.JsonNet;
    using NodaTime.Text;
    using System;
    
    public class DateObj
    {
        public ZonedDateTime Date { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var date = "2017-10-26 13:32:11 Etc/GMT";
            var json = $"{{\"Date\": \"{date}\"}}";
    
            var pattern = ZonedDateTimePattern.CreateWithInvariantCulture(
                "yyyy-MM-dd HH:mm:ss z",
                DateTimeZoneProviders.Tzdb
            );
    
            var settings = new JsonSerializerSettings
            {
                DateParseHandling = DateParseHandling.None,
                Converters = { new NodaPatternConverter<ZonedDateTime>(pattern) }
            };
            var dateObj = JsonConvert.DeserializeObject<DateObj>(json, settings);
            Console.WriteLine(dateObj.Date);
        }
    }

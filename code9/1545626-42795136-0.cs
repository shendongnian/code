    using NodaTime;
    using System;
    
    class Test
    {
        static void Main()
        {
            // My availability: 4pm-7pm in London        
            var jon = new Availability(
                DateTimeZoneProviders.Tzdb["Europe/London"],
                new LocalTime(16, 0, 0),
                new LocalTime(19, 0, 0));
            // My friend Richard's availability: 12pm-4pm in New York
            var richard = new Availability(
                DateTimeZoneProviders.Tzdb["America/New_York"],
                new LocalTime(12, 0, 0),
                new LocalTime(16, 0, 0));
            
            // Let's look through all of March 2017...
            var startDate = new LocalDate(2017, 3, 1);
            var endDate = new LocalDate(2017, 4, 1);
            for (LocalDate date = startDate; date < endDate; date = date.PlusDays(1))
            {
                var overlap = GetAvailableOverlap(date, jon, richard);
                Console.WriteLine($"{date:yyyy-MM-dd}: {overlap:HH:mm}");
            }
        }
        
        static Duration GetAvailableOverlap(
            LocalDate date,
            Availability avail1,
            Availability avail2)
        {
            // TODO: Check that the rules of InZoneLeniently are what you want.
            // Be careful, as you could end up with an end before a start...
            var start1 = (date + avail1.Start).InZoneLeniently(avail1.Zone);
            var end1 = (date + avail1.End).InZoneLeniently(avail1.Zone);
            
            var start2 = (date + avail2.Start).InZoneLeniently(avail2.Zone);
            var end2 = (date + avail2.End).InZoneLeniently(avail2.Zone);
            
            var latestStart = Instant.Max(start1.ToInstant(), start2.ToInstant());
            var earliestEnd = Instant.Min(end1.ToInstant(), end2.ToInstant());
            
            // Never return a negative duration... return zero of there's no overlap.
            // Noda Time should have Duration.Max really...
            var overlap = earliestEnd - latestStart;
            return overlap < Duration.Zero ? Duration.Zero : overlap;
        }
    }
    
    public sealed class Availability
    {
        public DateTimeZone Zone { get; }
        public LocalTime Start { get; }
        public LocalTime End { get; }
        
        public Availability(DateTimeZone zone, LocalTime start, LocalTime end)
        {
            Zone = zone;
            Start = start;
            End = end;
        }
    }

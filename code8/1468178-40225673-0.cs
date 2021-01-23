    using NodaTime.TimeZones;
    using NodaTime.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            // Paris went forward from UTC+1 to UTC+2
            // at 2am local time on March 29th 2015, and back
            // from UTC+2 to UTC+1 at 3am local time on October 25th 2015.
            var zone = DateTimeZoneProviders.Tzdb["Europe/Paris"];
            
            ResolveLocal(new LocalDateTime(2015, 3, 29, 2, 30, 0), zone);
            ResolveLocal(new LocalDateTime(2015, 6, 19, 2, 30, 0), zone);
            ResolveLocal(new LocalDateTime(2015, 10, 25, 2, 30, 0), zone);
        }
        
        static void ResolveLocal(LocalDateTime input, DateTimeZone zone)
        {
            // This can be cached in a static field; it's thread-safe.
            var resolver = Resolvers.CreateMappingResolver(
                Resolvers.ReturnEarlier, ShiftForward);
            
            var result = input.InZone(zone, resolver);
            Console.WriteLine("{0} => {1}", input, result);
        }
        
        static ZonedDateTime ShiftForward(
            LocalDateTime local,
            DateTimeZone zone,
            ZoneInterval intervalBefore,
            ZoneInterval intervalAfter)
        {
            var instant = new OffsetDateTime(local, intervalBefore.WallOffset)
                .WithOffset(intervalAfter.WallOffset)
                .ToInstant();
            return new ZonedDateTime(instant, zone);
        }            
    }

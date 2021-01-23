    public class LondonOffsetZone : DateTimeZone
    {
        private readonly DateTimeZone london;
        // This assumes London has a minimum of +0 and a maximum of +1.
        // To do it better, you'd resolve Europe/London and find *its*
        // min/max, and add -5 hours to each.
        public LondonOffsetZone()
            : base("LondonOffset", false, Offset.FromHours(-5), Offset.FromHours(-4))
        {
            london = DateTimeZoneProviders.Tzdb["Europe/London"];
        }
        public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);
        // Base Equals method will have handled reference equality already.
        protected override bool EqualsImpl(DateTimeZone other) => false;
        public override ZoneInterval GetZoneInterval(Instant instant)
        {
            // Return the same zone interval, but offset by 5 hours.
            var londonInterval = london.GetZoneInterval(instant);
            return new ZoneInterval(
                londonInterval.Name,
                londonInterval.Start,
                londonInterval.End,
                londonInterval.WallOffset + Offset.FromHours(-5),
                londonInterval.Savings);
        }
    }

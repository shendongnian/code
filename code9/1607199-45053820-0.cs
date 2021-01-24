    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class AssemblyPulishDateTime : Attribute
    {
        private readonly long _ticks;
        public DateTime UtcPublishDateTime
        {
            get { return new DateTimeOffset(_ticks, TimeSpan.Zero).UtcDateTime; }
        }
        public AssemblyPulishDateTime(long utcTicks)
        {
            _ticks = utcTicks;
        }
    }

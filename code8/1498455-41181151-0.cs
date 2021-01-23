    public sealed class Day
    {
        private Day(float rate)
        {
            m_Rate = rate;
        }
        private readonly float m_Rate;
        public float Rate { get { return m_Rate; } }
        public static readonly Day Saturday = new Day(1.5f);
        public static readonly Day Sunday = new Day(2f);
        public static readonly Day Monday = new Day(1f);
        public static readonly Day Tuesday = new Day(1f);
        public static readonly Day Wednesday = new Day(1f);
        public static readonly Day Thursday = new Day(1f);
        public static readonly Day Friday = new Day(1f);
        public static implicit operator float(Day day)
        {
            return day.m_Rate;
        }
    }

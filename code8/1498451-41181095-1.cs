    public struct Day
    {
        public Day(int key, float rate)
        {
            _key = key;
            _rate = rate;
        }
        private readonly int _key;
        private readonly float _rate;
        public int Key => _key;
        public float Rate => _rate;
        public static readonly Day
            Monday = new Day(0, 1f),
            Tuesday = new Day(0, 1f), ...;
        public static implicit operator int(Day day) => day.Key;
    }

        public class StatProperty
        {
            public Stats Stats { get; }
            public StatProperty(Stats stats)
            {
                Stats = stats;
            }
            private int _value = 1;
            public int Value
            {
                get => Stats.HasBuff ? _value + 1 : _value;
                set
                {
                    if (value < 1 || value > 10)
                        throw new ArgumentOutOfRangeException("Invalid value");
                    _value = value;
                }
            }
        }

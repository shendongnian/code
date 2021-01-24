        public class Stats
        {
            private readonly StatProperty _defense;
            private readonly StatProperty _attack;
            private readonly StatProperty _speed;
            public Stats()
            {
                _defense = new StatProperty(this);
                _attack = new StatProperty(this);
                _speed = new StatProperty(this);
            }
            public int Defense
            {
                get => _defense.Value;
                set => _defense.Value = value;
            }
            public int Attack
            {
                get => _attack.Value;
                set => _attack.Value = value;
            }
            public int Speed
            {
                get => _speed.Value;
                set => _speed.Value = value;
            }
            public bool HasBuff { get; set; }
        }

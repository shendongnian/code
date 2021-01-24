    class Stats
    {
        // other existing code here
        private int defense;
        public int Defense
        {
            get
            {
                return GetValue(defense);
            }
            set
            {
                SetValue(value, ref defense);
            }
        }
        private int GetValue(int value)
        {
            return HasBuff ? value + 1 : value;
        }
        private void SetValue(int value, ref int target)
        {
            if (value < 1 || value > 10)
                throw new ArgumentOutOfRangeException("Invalid value");
            target = value;
        }
    }

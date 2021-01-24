    public class Stat
    {
        public bool HasBuff { get; set; }
    
        private int _stat;
        public int Score
        {
            get => HasBuff ? _stat + 1 : _stat;
            set => _stat = value;
        }
    }

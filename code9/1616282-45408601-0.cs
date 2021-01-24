    public interface IReminder
    {
        public long Id { get; }
        public string Name { get; }
        public string Date { get; }
        public string RepeatType { get; }
        public string Note { get; }
        public long Enabled { get; }
        public string SoundFilePath { get; }
        public string PostponeDate { get; }
        public Nullable<long> EveryXCustom { get; }
        public string RepeatDays { get; }
        public Nullable<long> DayOfMonth { get; }
    }

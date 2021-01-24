    public AlarmStatusProvider
    {
        ...
        string Data { get { return this.data; } }
    }
    public class Alarm
    {
        private readonly AlarmStatusProvider provider;
        public Alarm(AlarmStatusProvider provider)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
        public void UpdateAlarmStatus()
        {
            // update AlarmStatus based on this.provider.Data
        }
        public AlarmId AlarmId { get; private set; }
        public AlarmType AlarmType { get; private set; }
        public Comparison Comparison { get; private set; }
        public double LowThreshold { get; private set; }
        public double HighThreshold { get; private set; }
        public DateTime Timestamp { get; private set; }
        public AlarmStatus AlarmStatus { get; private set; }
    }

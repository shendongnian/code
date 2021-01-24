    public interface IAlarmStatusProvider
    {
        Data DataDataToEvaluateAgainst { get; }
    }
    public class Alarm
    {
        private readonly IAlarmStatusProvider provider;
        public Alarm([NotNull] IAlarmStatusProvider provider)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
        public void UpdateAlarmStatus()
        {
            this.UpdateAlarmStatus(this.provider.DataDataToEvaluateAgainst);
        }
        public AlarmId AlarmId { get; private set; }
        public AlarmType AlarmType { get; private set; }
        public Comparison Comparison { get; private set; }
        public double LowThreshold { get; private set; }
        public double HighThreshold { get; private set; }
        public DateTime Timestamp { get; private set; }
        public AlarmStatus AlarmStatus { get; private set; }
    }

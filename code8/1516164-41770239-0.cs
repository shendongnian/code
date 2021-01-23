    public class RootObject
    {
        public List<SchedulePeriod> schedulePeriods { get; set; }
    }
    public class SchedulePeriod
    {
        public string day { get; set; }
        public string periodType { get; set; }
        public int startTime { get; set; }
        public bool isCancelled { get; set; }
        public double heatSetpoint { get; set; }
        public double coolSetpoint { get; set; }
        public string fanMode { get; set; }
    }

    public class TimeRange : TimeShift
    {
        public TimeRange(string name, TimeSpan start, TimeSpan end) : base(start, end)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    public class TimeShift
    {
        public TimeShift(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }

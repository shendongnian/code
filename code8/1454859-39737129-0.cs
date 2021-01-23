    public class DayScheduleVM
    {
        public bool IsRequired { get; set; } // this will be used for conditional validation
        [RequiredIf("IsRequired", ErrorMessage = "Please enter the start time")]
        public TimeSpan? StartTime { get; set; }
        [RequiredIf("IsRequired", ErrorMessage = "Please enter the end time")]
        public TimeSpan? EndTime { get; set; }
        [RequiredIf("IsRequired", ErrorMessage = "Please enter the interval")]
        public TimeSpan? Interval { get; set; }
    }
    public WeekScheduleVM
    {
        public DayScheduleVM Sunday { get; set; }
        public DayScheduleVM Monday { get; set; }
        ....
    }

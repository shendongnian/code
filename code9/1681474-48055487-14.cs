    [Flags]
    public enum ScheduleDays
    {
        None = 0x00,
        Monday = 0x01,
        Tuesday = 0x02,
        Wednesday = 0x04,
        Thursday = 0x08,
        Friday = 0x10,
        Saturday = 0x20,
        Sunday = 0x40,
        All = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
    }
    public class Schedule
    {
        public DateTime Start;
        public ScheduleDays Days; // ScheduleDay.None by default
    } 

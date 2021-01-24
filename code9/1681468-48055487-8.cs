    [Flags]
    public enum ScheduleDays
    {
        None,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
        All = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday
    }
    public class Schedule
    {
        public DateTime Start;
        public ScheduleDays Days; // ScheduleDay.None by default
    } 

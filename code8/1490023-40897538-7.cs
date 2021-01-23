    public class StaffSchedule
    {
        public int StaffId { get; set; }
        public int ScheduleId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Schedule Schedule { get; set; }
        public DateTime Date { get; set; }
    }

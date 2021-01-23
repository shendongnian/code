    public class Schedule
    {
        public int Id { get; set; }
        //Other Fields
        public ICollection<StaffSchedule> StaffSchedules { get; set; }
    }
    
    public class Staff
    {
        public int Id { get; set; }
        //Other Fields
        public ICollection<StaffSchedule> StaffSchedules { get; set; }
    }

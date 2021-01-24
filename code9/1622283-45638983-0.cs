    public class TaskInfo
    {
        public int TaskInfoId { get; set; }
        public int ExecId { get; set; }
        .../...
        // public virtual DriverInfo DriverInfo { get; set; }
        public virtual JobData JobData { get; set; }
    }

    public class TaskInfo
    {
        public int TaskInfoId { get; set; }
        public int ExecId { get; set; }
        .../...
        public int DriverInfoId  { get; set; } // The PK of DriverInfo
        public virtual DriverInfo DriverInfo { get; set; }
    }

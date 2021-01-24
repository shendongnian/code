    public class DriverInfo
    {       
        public int DriverId { get; set; }
           
        [ForeignKey("TaskInfoId")]
        public int TaskInfoIdFK { get; set;}
        public int DriverInfoId { get; set; }
        public virtual TaskInfo TaskInfo { get; set; }
    }

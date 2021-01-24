    public class Attendance
    {
        public int DriverId { get; set; }
        [Display(Name = "Name")]
        public string DriverName { get; set; }
        [Display(Name = "Driver In")]
        public bool DriverIn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DriverInDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DriverOutDateBefore { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DriverInDateBefore { get; set; }
        [Display(Name = "Driver Out")]
        public bool DriverOut { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DriverOutDate { get; set; }
        public int UnitId { get; set; }
        [Display(Name = "Police Number")]
        public string PoliceNumber { get; set; }
        [Display(Name = "Unit In")]
        public bool UnitIn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UnitInDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UnitOutDateBefore { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UnitInDateBefore { get; set; }
        [Display(Name = "Unit Out")]
        public bool UnitOut { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UnitOutDate { get; set; }
    }

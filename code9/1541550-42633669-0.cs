    public class EmployeeRegion
    {
        [Key, Column(Order = 1)]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Key, Column(Order = 2)]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    
        public int PatientId { get; set; }
        public int StaffId { get; set; }
    
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
    }

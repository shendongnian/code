    public class SupportProcess
    {
        [Key]
        public int ProcessId { get; set; }
        [DisplayName("Starting process?")]
        public int StartProcessId { get; set; }
        [ForeignKey("StartProcessId")]
        public virtual SupportProcess StartProcess { get; set; }
        public string Name { get; set; }
        [DisplayName("When is this run?")]
        public virtual ProcessSchedule ProcessSchedule { get; set; }
        [DisplayName("")]
        public string Description { get; set; }
        [DisplayName("Expected Result")]
        public string ExpectedResult { get; set; }
    }

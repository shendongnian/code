    [Table("P_ChimeTime")]
    public class ChimeTime
    {
        [Key]
        public int chimeTimeID { get; set; }
        public Schedule ScheduleID { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:T}", ApplyFormatInEditMode = true)]
        public DateTime ChimeTimeStamp { get; set; }
        [ForiegnKey("ScheduleID")]
        public int schedule {get; set;}
    }

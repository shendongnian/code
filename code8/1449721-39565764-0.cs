    public class Report
    {
        [Required]
        public string State { get; set; }
        [Column("reporter_id")]
        public string ReporterId { get; set; }
        [Required]
        [Column("report_text")]
        public string ReportText { get; set; }
        public string UserName{ get; set; }
    }

    public class JobSurvey
    {
        [Key, ForeignKey("First")]
        public int JobSurveyId { get; set; }
    
        public string CustomerEmail { get; set; }
    
        [Index]
        [Column(TypeName = "Date")]
        public DateTime? SentDate { get; set; }
    
        [Column(TypeName = "Date")]
        public DateTime? ReturnedDate { get; set; }
    
        public int? RatingValue { get; set; }
    
        public virtual Job Job { get; set; }
    }

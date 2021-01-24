    [Table("Applicant")]
    public class Applicant
    {
        [Index]
        [Key]
        public int ApplicantID { get; set; }
    
        // other properties
    
        public virtual ApplicantNotification Notification { get; set; }
    }
    
    
    [Table("ApplicantNotification")]
    public class ApplicantNotification
    {
        [Index]
        [Key, ForeignKey("Applicant")]
        public int ApplicantNotificationID { get; set; }
    
        // other properties
    
        public virtual Applicant Applicant { get; set; }
    }

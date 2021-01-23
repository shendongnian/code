    public class Job
    {
        [Key]
        public int JobID { get; set; }
        public virtual JobSurvey JobSurvey { get; set; }
    }
    public class JobSurvey
    {
        [Key, ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
        /* other properties */
    }

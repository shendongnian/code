	public class Job
	{
		[Key]
		public int JobID { get; set; }
		
		public virtual JobSurvey JobSurvey { get; set; }
	}
	public class JobSurvey
	{
		[Key]
		public int JobSurveyId { get; set; } // This is also foreign key to Job
		
		public virtual Job Job { get; set; }
	}

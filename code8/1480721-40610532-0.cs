    public class Job
    {
    	public int Id { get; set; }
    
    	public int? JobId { get; set; }
    
    	public Job ParentJob { get; set; }
    
    	public ICollection<Job> ChildJobs { get; set; }
    }

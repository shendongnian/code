    public class Job
    {
        public string JobId { get; set; }
        public string Name { get; set; }
        public string Location {get; set; }
    }
    
    public class JobModel
    {
        public List<Job> AllJobs { get; set; }
        public Job SelectedJob { get; set; }
    }

    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime LastActivity { get; set; }
        public IList<string> Tags { get; set; }
        public IList<string> Branches { get; set; }
        public IList<CommitActivity> Commits { get; set; }
    }
    
    public class CommitActivity
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public long SizeInBytes { get; set; }
    }

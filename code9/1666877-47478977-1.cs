    public class WorkItem
    {
        public Guid Id { get; set; }
    
        public string Description { get; set; }
    
        [ForeignKey("Person")]
        public Guid WorkItemCreatorId{ get; set; }
        public Person Creator { get; set; }
    
    }

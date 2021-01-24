    public class Person
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; }
    
        public ICollection<WorkItem> Tasks { get; set; }
    }

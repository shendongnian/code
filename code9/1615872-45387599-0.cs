    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // an Employee works in zero or more Projects
        public virtual ICollection<Project> Projects { get; set; }
    }

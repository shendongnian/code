    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Employee> Assistants { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
    }
    public class Manager : Employee
    {
        public IEnumerable<Employee> DirectReports { get; set; }
    }

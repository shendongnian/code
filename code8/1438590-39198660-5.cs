    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmployeeAssistant> Assistants { get; set; } //if an employee has no assistants this List can easily just be empty
        OR
        public ICollection<EmployeeAssistant> Assistants { get; set; } // depending on your architecture, choose the one that would suit you better
    }
    public class EmployeeAssistant
    {
       [ForeignKey("Employee")]
       public int EmployeeId { get; set; } //this is the employee who 'has' this assistant
       public virtual Employee Employee { get; set; }
    
       public int Id { get; set; }  //this is the assistant's own information - identical to employee's basic info
       public string FirstName { get; set; }
       public string LastName { get; set; }
    }

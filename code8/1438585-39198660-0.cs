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
       public int EmployeeId { get; set; }
       public virtual Employee Employee { get; set; }
    
       //[ForeignKey("Assistant")]
       //public int AssistantId { get; set; }
       //public virtual Employee Assistant { get; set; }
       //Since Assistants are also employees, you don't need a separate definition here
    }

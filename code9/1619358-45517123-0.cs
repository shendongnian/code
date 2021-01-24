    public class Employee {
        public int Employee Id { get; set; }
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }
    }

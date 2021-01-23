    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
    
        ForeignKey("Person")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
    
    
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
      
        public virtual Department Department { get; set; }
    }

    public class Department
    {
        public Department(){} //needed constructor
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Employee")]
        public int Employee_Id;
        public virtual ICollection<Employee> Employee { get; set; }
    }
    public class Employee
    {
        public Employee(){} //needed constructor
        public int Id { get; set; }
        public string Name { get; set; }
        public long Salary { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Department")]
        public int Department_Id;
        public virtual Department Department { get; set; }
    }

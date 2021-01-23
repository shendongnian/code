    public class Employee
    {
        public Employee() { }
    
        public static SchoolEmployeesContext ctx = new SchoolEmployeesContext();
    
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfCommencement { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    
        public Department DepartmentOfEmployee { get; set; }
    
    }

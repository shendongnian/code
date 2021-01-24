    public class Employee
    {
        public int EmployeeId{ get; set; }
    
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public int Benefits { get; set; }
        // an employee has many departments:
        public virtual ICollection<Department> Departments { get; set; }
    }
    public class Department
    {
        public int DeptartmentId { get; set; }
        public string DeptName { get; set; }
        // an department has many employees
        public virtual ICollection<Employee> Employees{ get; set; }
    }
    public MyDbContext : DbContext
    {
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Department> Departments {get; set;}
    }

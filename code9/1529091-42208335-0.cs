    public class Model
    {
       public List<Employee> Employees { get; set; }
    }
    public class Employee
    {
       public string EmployeeId { get; set; }
       public string EmployeeName { get; set; }
       public Department Department { get; set; }
    }
    public class Department
    {
       public string DepartmentId { get; set; }
       public string DepartmentName {get; set; }
       public Address Address { get; set; }
    }
    public class Address
    {
       public string AddrOne { get; set; }
       public string City { get; set; }
    }

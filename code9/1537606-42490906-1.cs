    public class Employee
    {
        public virtual string EmployeeType { get { return "Employee"; } }
    }
    public class FullTimeEmp : Employee { 
        public override string EmployeeType { get { return "FullTimeEmp"; } }
    }

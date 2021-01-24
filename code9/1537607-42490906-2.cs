    public abstract class Employee
    {
        public abstract string EmployeeType { get; }
    }
    public class FullTimeEmp : Employee { 
        public override string EmployeeType { get { return "FullTimeEmp"; } }
    }

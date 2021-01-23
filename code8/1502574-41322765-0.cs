    public abstract class EmployeeBase{}
    public class Employee: EmployeeBase{}
    class SomeClass
    {
        public EmployeeBase Employee { get; set; }
        SomeClass()
        {
            Employee = new Employee(); // OOP in play :)
            Employee = new EmployeeBase(); // Error CS0144  
            // Cannot create an instance of the abstract class or interface 'EmployeeBase'
        }
    }

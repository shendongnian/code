    public interface IEmployee
    {
        int Id { get; set;}
        int Name { get; set;}
    }
    public abstract class Employee : IEmployee
    {
        public int Id { get; set;}
        public int Name { get; set;}
    }
    public class PermanentEmployee: Employee
    {
         // PermanentEmployee specific props
    }
    public class ContractEmployee : Employee
    {
        //Contractor​ specific properties
    }

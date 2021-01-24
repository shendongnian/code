    public abstract class Employee
    {
        public abstract string Type { get; }
    }
    public class FullTimeEmployee : Employee
    {
        public override string Type { get; } = "Full Time";
    }

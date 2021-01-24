     public abstract class Employee
        {
            public abstract string Type { get; }
        }
    
        public class FullTimeEmployee : Employee
        {
            public FullTimeEmployee()
            {
                this.Type = "Full Time";
            }
            public override string Type { get; private set; }
        }

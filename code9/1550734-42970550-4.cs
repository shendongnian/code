    abstract class BaseEmployee
    {
        abstract double CalculateSalary(...);
        public void PaySalary()
        {
           double salary = this.CalculateSalary(...);
           ...
        }
    }

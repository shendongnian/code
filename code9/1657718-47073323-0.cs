     class Program
    {
        static void Main(string[] args)
        {
            Salarycalculator salaryCalculator = new Salarycalculator();
            salaryCalculator.calculate(new Architect());
        }
    }
    public class Salarycalculator
    {
        public void calculate(IEmployee employee)
        {
            employee.CalculateSalary();
        }
    }
    public interface IEmployee
    {
        void CalculateSalary();
    }
    public class Developer : IEmployee
    {
        public void CalculateSalary()
        {
        }
    }
    public class Architect : IEmployee
    {
        public void CalculateSalary()
        {
        }
    }
    }

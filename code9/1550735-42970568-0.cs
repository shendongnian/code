    public class Report
    {
        public SalaryReport Generate(BaseEmployee employee)
        {
            // ...
            var salary = employee.CalculateSalary();
            // ...
        }
    }

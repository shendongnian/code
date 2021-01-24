    interface ISalaryReceiver
    {
        double CalculateSalary(int hoursWorked);
    }
    class BaseEmployee
    {
        public string EmployeeID { get; set; }
        ...
    }
    class FullTimeEmployee : BaseEmployee, ISalaryReceiver
    {
        public override double CalculateSalary(int hoursWorked)
        {
            ...
        }
    }
    class ContractEmployee : BaseEmployee, ISalaryReceiver
    {
        public double CalculateSalary(int hoursWorked)
        {
            ...
        }
    }
    void PaySalary(List<ISalaryReceiver> employees)
    {
        ...
    }

    public class EmployeeService 
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeePrinter _printer;
        public EmployeeService(IEmployeeRepository employeeRepository, 
            IEmployeePrinter printer)
        {
            _employeeRepository = employeeRepository;
            _printer = printer;
        }
        public void PrintEmployee(Employee employee)
        {
            _printer.PrintEmployee(employee);
        }
    }

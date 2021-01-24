    class EmployeeService : IEmployeeService
    {
        protected readonly IPrintService _printService;
 
        public EmployeeService(IPrintService printService)
        {
            _printService = printService; //injected
        }
  
        public void Print(Employee employee)
        {
            _printService.Print(employee.ToString());
        }
    }

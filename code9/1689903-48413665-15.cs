    class Application
    {
        protected readonly IEmployeeService _employeeService;
        protected readonly IPrintService _printService;
        public Application(IEmployeeService employeeService, IPrintService printService)
        {
            _employeeService = employeeService; //Injected
            _printService = printService; //Injected
        }
        public void Run()
        {
            var employee = _employeeService.GetEmployee();
            _printService.Print(employee);
        }
    }

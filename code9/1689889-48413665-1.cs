    class Application
    {
        protected readonly ISomeService _someService;
        protected readonly IPrintService _printService;
        public Application(ISomeService someService, IPrintService printService)
        {
            _someService = someService; //Injected
            _printService = printService; //Injected
        }
        public void Run()
        {
            var employee = _someService.GetEmployee();
            _printService.Print(employee);
        }
    }

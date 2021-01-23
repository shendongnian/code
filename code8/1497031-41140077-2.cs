    public sealed class HomeController : ApiController
    {
        private readonly IRepository<Employee> _employeeRepository;
        public HomeController(IRepository<Employee> employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return this._employeeRepository.GetAll();
        }
    }
    

    public interface IUnitOfWork
    {
        IRepository<TModel> Repository<TModel>();
    }
    public sealed class HomeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            return this._unitOfWork.Repository<Employee>().GetAll();
        }
    }

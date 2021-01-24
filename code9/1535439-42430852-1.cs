    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private Repository<Order> _repository;
    
        public ValuesController(Repository<Order> repository)
        {
            _repository = repository;
        }
    }

    [Route("api/user")]
    public class UserController : Controller
    {   
        private IUserRepository _repository { get; set; }
        public UserController(IUserRepository  repository)
        {
            _repository = repository;
        }
    }

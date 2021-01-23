    public class ApiController : Controller
    {
        private readonly UserRepository_userRepository;
        public ApiController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<IActionResult> Get() 
        {
           // Just access your repository here and get the user
           var user = _userRepository.GetUser(1);
           return Ok(user);
       }
    }
    
    namespace Infrastructure
    {
        public class UserRepository
        {
            public readonly IMemoryCache _memoryCache;
            public UserRepository(IMemoryCache cache)
            {
                _memoryCache = cache;
            }
        
            public User GetUser(Id)
            {
                // use _memoryCache here
            }
         }
    }
    
    // Startup.cs#ConfigureServices
    services.AddMemoryCache();

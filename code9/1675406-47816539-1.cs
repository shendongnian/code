    public class UserService : IUserService {
        private readonly HttpContext _context;
     
        public UserService(IHttpContextAccessor httpContextAccessor) {
            _context = httpContextAccessor.HttpContext;
        }
    }

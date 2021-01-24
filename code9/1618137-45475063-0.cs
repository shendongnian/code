    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IIdentityService _identityService;
    
        public BaseController(ApplicationDbContext context, IIdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        } 
    
         //reusable methods
         public async Task<Account> GetAccount()
         {
            //code to do something, i.e query database
         }
    
    
    }

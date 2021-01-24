    public class ThePolicyRequirement : IAuthorizationRequirement
        {
            AppDbContext _context;
            IHttpContextAccessor _contextAccessor;
    
            public async Task<bool> Pass(AppDbContext context, IHttpContextAccessor contextAccessor, string area, string controller, string action, string id)
            {
                _context = context;
                _contextAccessor = contextAccessor;
                
                //authorization logic goes here
    
                return await Task.FromResult(false);
            }
        }

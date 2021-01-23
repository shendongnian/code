    private readonly BloggingContext _context;
    public class SecurityService : ISecurityService
    {
        public SecurityService (BloggingContext context)
        {
            _context = context
        }
    }

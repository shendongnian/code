    public class PrincipalProvider : IPrincipalProvider
    {
    
        // Readonly fields
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrincipalProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    
        /// <summary>
        /// Gets the current user
        /// </summary>
        public IPrincipal User => _httpContextAccessor.HttpContext?.User;
    }

    public class SomeClass
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        public SomeClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }

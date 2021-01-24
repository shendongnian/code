    public class SecurityHeadersBuilder
    {
        private readonly SecurityHeaderOptions _options;
        public SecurityHeadersBuilder(IOptions<SecurityHeaderOptions> options)
        {
            _options = options.Value;    
        }
        
        public SecurityHeadersBuilder(SecurityHeaderOptions options)
        {
            _options = options;    
        }
        public SecurityHeadersBuilder AddDefaultPolicy()
        {
            AddFrameOptions();
            AddContentSecurityPolicy();
            return this;
        }
    }

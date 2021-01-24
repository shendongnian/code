    public interface ISecurityHeadersBuilder
    {
        SecurityHeadersBuilder AddDefaultPolicy;    
    }
    public class SecurityHeadersBuilder : ISecurityHeadersBuilder
    {
        private readonly SecurityHeaderOptions _options = null;
    
        public SecurityHeadersBuilder(IOptions<SecurityHeaderOptions> options)
        {
            _options = options.Value;    
        }
    
        public SecurityHeadersBuilder AddDefaultPolicy()
        {
            AddFrameOptions();
            AddConetntSecurityPolicy();
            return this;
        }
     }

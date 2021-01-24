    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly IMyService _myService;
    
        public ConfigureJwtBearerOptions(IMyService myService)
        {
            // ConfigureJwtBearerOptionsis constructed from DI, so we can inject anything here
            _myService = myService;
        }
    
        public void Configure(string name, JwtBearerOptions options)
        {
            // check that we are currently configuring the options for the correct scheme
            if (name == JwtBearerDefaults.AuthenticationScheme)
            {
                options.TokenValidationParameters = myService.GetTokenValidationParameters();
            }
        }
    
        public void Configure(JwtBearerOptions options)
        {
            // default case: no scheme name was specified
            Configure(string.Empty, options);
        }
    }

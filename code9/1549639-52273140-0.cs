        public void ConfigureServices(IServiceCollection services)
        {
            // secOpts available for use in ConfigureServices
            var secOpts = Configuration
            .GetSection("SecurityHeaderOptions")
            .Get<SecurityHeaderOptions>();
            
            ...
        }

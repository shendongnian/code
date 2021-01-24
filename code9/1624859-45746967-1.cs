        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizeAttribute
                {
                    ActiveAuthenticationSchemes = "BasicAuth" 
                });
            });
        
            //snip
        }
    And overriding it:
        [AllowAnonymous]
        public string UnsecureAction()
        {
            //snip
        }

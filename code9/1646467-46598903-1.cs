        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
                {
                    #region AddUtilsConfig
        
                    serviceProvider.SetUtilsProviderConfiguration(Configuration);
        
                    #endregion
    
    ...

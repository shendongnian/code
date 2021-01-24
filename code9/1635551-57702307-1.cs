 public void Configure(IApplicationBuilder app, IHostingEnvironment env, NorthwindContext context, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            ....
        }

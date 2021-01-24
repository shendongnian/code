        using NLog.Extensions.Logging;
        using NLog.Web;
        using Nlog;
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //setup logging
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
            app.AddNLogWeb();
            // other unrelated stuff...
        }

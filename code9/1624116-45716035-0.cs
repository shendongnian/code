    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
        var jm = app.ApplicationServices.GetService<JobManager>();
        jm.StartAsync();
        // etc
    }

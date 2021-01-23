    using Hangfire;
    using Hangfire.MemoryStorage;
    public void ConfigureServices(IServiceCollection services) 
    {
        services.AddHangfire(opt => opt.UseMemoryStorage());
        JobStorage.Current = new MemoryStorage();
    }
    protected void StartHangFireJobs(IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        app.UseHangfireServer();
        app.UseHangfireDashboard();
        //TODO: move cron expressions to appsettings.json
        RecurringJob.AddOrUpdate<SomeJobService>(
            x => x.DoWork(),
            "* * * * *");
        RecurringJob.AddOrUpdate<OtherJobService>(
            x => x.DoWork(),
            "0 */2 * * *");
    }
    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        StartHangFireJobs(app, serviceProvider)
    }

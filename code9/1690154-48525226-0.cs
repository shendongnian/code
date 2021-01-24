    public void Configuration(IAppBuilder app)
    {
        GlobalConfiguration.Configuration.UseSqlServerStorage("<connection string or its name>");
    
        app.UseHangfireDashboard();
        app.UseHangfireServer();
    }

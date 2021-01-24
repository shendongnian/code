    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime, IServiceProvider sp)
    {
        var props = new dashboard.Models.Tracking.Tracker.Props {
                dbConn = (sp.GetService<DATABASEContext>() as COTSContext).Database.GetDbConnection().ConnectionString,
                dbName = "DATABASE",
                dbTable = "TABLE"
            };
        Models.Tracking.Tracker.Start(props, sp);
    }

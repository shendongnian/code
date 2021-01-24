    public override Task Invoke(IOwinContext context)
    {
        var app = ConfigurePipeline(context);
        var dynamicAppFunc = app.Build();
        return dynamicAppFunc(context.Environment);
    }
    private IAppBuilder ConfigurePipeline(IOwinContext context)
    {
        var app = new AppBuilder();
                       
        app.UseIdentityServer(GetOptions(context));
           
        app.Run(_next.Invoke);
        return app;
    }

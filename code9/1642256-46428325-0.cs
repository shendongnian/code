    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        pipelines.AfterRequest += (ctx) =>
        {
            ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                        .WithHeader("Access-Control-Allow-Methods", "POST, GET, DELETE, PUT, OPTIONS, PATCH")
                        .WithHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization")
                        .WithHeader("Access-Control-Max-Age", "3600");
        }
    }

    using Microsoft.AspNetCore.HttpOverrides;
    ....
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        ...
        // UseForwardedHeaders must be BEFORE the UseIdentityServer.
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedProto
        });
        app.UseIdentityServer();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        if (!Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.DisableTelemetry)
        {
           app.UseApplicationInsightsRequestTelemetry();
           app.UseApplicationInsightsExceptionTelemetry();
        }
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        app.UseIISPlatformHandler();
        app.UseExceptionHandler(options => {
            options.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
                    await context.Response.WriteAsync(err).ConfigureAwait(false);
                }
            });
        });
        app.UseStaticFiles();
        app.UseMvc();
    }

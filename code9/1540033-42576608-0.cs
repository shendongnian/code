    // add the NuGet package `NLog.Web.AspNetCore` as a project dependency,
    // which makes these namespaces available: 
    using NLog.Extensions.Logging;
    using NLog.Web;
    // your ASP.NET Core startup / configuration class:
    partial class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            …
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            …
        }
    }

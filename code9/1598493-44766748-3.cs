    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Gives a happy little response when someone makes a request to healthCheckUrl
        /// </summary>
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app, string environmentName, string applicationName, string healthCheckUrl)
        {
            app.Map(healthCheckUrl, a =>
            {
                a.Run(async context =>
                {
                    await context.Response.WriteAsync($"{applicationName} is alive in environmentName");
                });
            });
            return app;
        }
    }

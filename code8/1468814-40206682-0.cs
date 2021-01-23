    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (http, next) =>
            {
                if (http.Request.IsHttps)
                {
                    // The request will continue if it is secure.
                    await next();
                }
                // In the case of HTTP request (not secure), end the pipeline here.
            });
            // ...Define other middlewares here, like MVC.
        }
    }

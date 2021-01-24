        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc();
            app.Run(async context =>
            {
                await context.Response.WriteAsync("API"); // returns a 200 with "API" as content.
            });
        }

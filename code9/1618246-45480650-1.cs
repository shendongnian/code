    public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // Do loging
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

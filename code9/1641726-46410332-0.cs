    public void Configure(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            context.Items.Add("RequestStartedOn", DateTime.UtcNow);
            await next();
        };
        //The rest of your code here...
    }

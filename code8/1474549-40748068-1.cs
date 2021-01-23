    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        var options = new JwtBearerOptions
        {
            Audience = "[Your API ID]",
            Authority = $"[URL for your identity provider]/",
            // certificate public keys will be read automatically from
            // the identity provider if possible
            // If using symmetric keys, you will have to provide them
        };
        app.UseJwtBearerAuthentication(options);
    }

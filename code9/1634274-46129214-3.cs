    public void Configure(IApplicationBuilder app, IApplicationLifetime applicationLifetime)
    {
        applicationLifetime.ApplicationStarted.Register(() =>
        {
            // application has started, request the singleton here to trigger DI to
            // create the instance
            app.ApplicationServices.GetService<ExpensiveSingleton>();
        });
        // …
    }
    }

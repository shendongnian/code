    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
 
    }
    if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
    {
        // do something here
    }

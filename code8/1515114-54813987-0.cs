    // The Tempdata provider cookie is not essential. Make it essential
    // so Tempdata is functional when tracking is disabled.
    services.Configure<CookieTempDataProviderOptions>(options => {
       options.Cookie.IsEssential = true;
    });

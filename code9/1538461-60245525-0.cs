    <i>I had a similar issue with ASP Net Core 3.0 The site hosting was in a different country causing issues with formats.
    I added the following to the startup:</i>
        using Microsoft.AspNetCore.Localization;
        using System.Globalization;
    
    <i>in ConfigureServices</i>
        services.AddLocalization();
    <i>in Configure:</i>
        var supportedCultures = new[]
                {
                    new CultureInfo("en-US")
                     
                                };
                app.UseRequestLocalization(new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture("en-US"),
                    SupportedCultures = supportedCultures,
                    FallBackToParentCultures= false
    
    
                });
                CultureInfo.DefaultThreadCurrentCulture = 
        CultureInfo.CreateSpecificCulture("en-US");

    public static IMvcBuilder AddMyLibrary(this IMvcBuilder builder, string prefix = "api/")
    {
        // instantiate the convention with the right selector for your library.
        // Check for namespace, marker attribute, name pattern, whatever your prefer
        var prefixConvention = new ApiPrefixConvention(prefix, (c) => c.ControllerType.Namespace == "WebApplication2.Controllers.Api");
        
        // Insert the convention within the MVC options
        builder.Services.Configure<MvcOptions>(opts => opts.Conventions.Insert(0, prefixConvention));
            
        // perform any extra setup required by your library, like registering services
        // return builder so it can be chained
        return builder;
    }

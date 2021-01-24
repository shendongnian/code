    services.AddMvc(opts =>
    {
        var prefixConvention = new ApiPrefixConvention("api/", (c) => c.ControllerType.Namespace == "WebApplication2.Controllers.Api");
        opts.Conventions.Insert(0, prefixConvention);
    });

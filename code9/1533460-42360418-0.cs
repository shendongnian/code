    public void ConfigureServices(IServiceCollection services)
    {
        // Build a customized MVC implementation, without using the default AddMvc(), instead use AddMvcCore().
        // https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs
        services
            .AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true; // does not affect api requests
                options.RespectBrowserAcceptHeader = true; // false by default
                //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.OutputFormatters.Add(new YourCustomOutputFormatter());
                options.InputFormatters.Add(new YourCustomInputFormatter());
            })
            //.AddApiExplorer()
            //.AddAuthorization()
            .AddFormatterMappings()
            //.AddCacheTagHelper()
            //.AddDataAnnotations()
            //.AddCors()
            .AddJsonFormatters();
    }

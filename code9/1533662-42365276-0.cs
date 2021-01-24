    public void ConfigureServices(IServiceCollection services)
    {
        // Build a customized MVC implementation, without using the default AddMvc(),
        // instead use AddMvcCore(). The repository link is below:
        // https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs
        services
            .AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true; // this does not affect api requests
                options.RespectBrowserAcceptHeader = true; // false by default
                //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                // these two are here to show you where to include custom formatters
                options.OutputFormatters.Add(new CustomOutputFormatter());
                options.InputFormatters.Add(new CustomInputFormatter());
            })
            //.AddApiExplorer()
            //.AddAuthorization()
            .AddFormatterMappings()
            //.AddCacheTagHelper()
            //.AddDataAnnotations()
            //.AddCors()
            .AddJsonFormatters();
    }

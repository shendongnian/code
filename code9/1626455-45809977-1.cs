    services.AddMvc(options =>
    {
        options.Filters.AddService(typeof(IExceptionFilter));
        // ASP.NET Core 2.0
        //options.Filters.AddService<IExceptionFilter>();
    });

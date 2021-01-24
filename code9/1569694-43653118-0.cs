    public static IWebHostBuilder Foo(this IWebHostBuilder webHostBuilder)
    {
        webHostBuilder.Configure(x =>
        {
            var service = x.ApplicationServices.GetService<IApplicationLifetime>();
        });
        return webHostBuilder;
    }

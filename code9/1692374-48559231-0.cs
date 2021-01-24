    ServiceProvider GetServiceProvider()
        {
            var collection = new ServiceCollection();
            collection.AddMvc();
            collection.AddOData();
            collection.AddTransient<ODataUriResolver>();
            collection.AddTransient<ODataQueryValidator>();
            collection.AddTransient<TopQueryValidator>();
            collection.AddTransient<FilterQueryValidator>();
            collection.AddTransient<SkipQueryValidator>();
            collection.AddTransient<OrderByQueryValidator>();
            return collection.BuildServiceProvider();
        }

    private static IServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();            
        serviceCollection.AddSingleton<IDynamoDBContext,DynamoDBContext>(p => new DynamoDBContext(new AmazonDynamoDBClient()));  
        return serviceCollection.BuildServiceProvider(); 
    }

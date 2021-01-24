    services.AddTransient<IDynamoDBContext>(c => new 
    DynamoDBContext(c.GetService<IAmazonDynamoDB>(),
                    new DynamoDBContextConfig 
                    { 
                        TableNamePrefix = Configuration.GetValue("MyEnvironment", unspecified")  + "-" 
                    }));

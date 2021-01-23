    var methodInfo = typeof(ServiceProviderServiceExtensions).
                GetTypeInfo().
                GetMethod("GetService").
                MakeGenericMethod(typeof(TDbContext));
    var providerParam = Expression.Parameter(typeof(IServiceProvider), "provider");
    var lambdaExpression = Expression.Lambda(
            Expression.Call( methodInfo, providerParam ),
            providerParam
            );
    var compiledLambdaExpression = lambdaExpression.Compile();

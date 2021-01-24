    public class LambdaEntryPoint : APIGatewayAuthorizerProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseApiGateway();
        }
    }

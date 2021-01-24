    public class TestingClientFactory : DefaultHttpClientFactory
    {
        public overrride HttpMessageHandler CreateMessageHandler()
        {
            var config = new HttpConfiguration();
            //configure web api
            config.MapHttpAttributeRoutes();
            return new HttpServer(config);
        }
    }

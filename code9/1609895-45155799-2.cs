    public class TestingClientFactory : DefaultHttpClientFactory
    {
        public overrride HttpMessageHandler CreateMessageHandler()
        {
            var config = new HttpConfiguration();
            //configure web api
            WebApiConfig.Register(config);
            return new HttpServer(config);
        }
    }

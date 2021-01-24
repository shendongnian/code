    public class CustomFlurlHttpClient : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler() {
            var socksProxy = new Socks5ProxyClient("127.0.0.1", 9150);
            return new ProxyHandler(socksProxy);
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(CustomHttpProxy.Register);
        }
    }
    public static class CustomHttpProxy
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Proxy",
                routeTemplate: "{*path}",
                handler: HttpClientFactory.CreatePipeline(
                    innerHandler: new HttpClientHandler(),
                    handlers: new DelegatingHandler[]
                    {
                        new ProxyHandler()
                    }
                ),
                defaults: new { path = RouteParameter.Optional },
                constraints: null
            );
        }
    }
    public class ProxyHandler : DelegatingHandler
    {
        private static HttpClient client = new HttpClient();
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var forwardUri = new UriBuilder(request.RequestUri.AbsoluteUri);
            forwardUri.Host = "localhost";
            forwardUri.Port = 62904;
            request.RequestUri = forwardUri.Uri;
            if (request.Method == HttpMethod.Get)
            {
                request.Content = null;
            }
            request.Headers.Add("X-Forwarded-Host", request.Headers.Host);
            request.Headers.Host = "localhost:62904";
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return response;
        }
    }

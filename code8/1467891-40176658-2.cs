    internal interface IHttpTestServer : IDisposable {
        HttpConfiguration Configuration { get; }
        HttpClient CreateClient();
    }
    internal class HttpTestServer : IHttpTestServer {
        HttpServer httpServer;
        public HttpTestServer(HttpConfiguration configuration = null) {
            httpServer = new HttpServer(configuration ?? new HttpConfiguration());
        }
        public HttpConfiguration Configuration {
            get { return httpServer.Configuration; }
        }
        public HttpClient CreateClient() {
            var client = new HttpClient(httpServer);
            return client;
        }
        public void Dispose() {
            if (httpServer != null) {
                httpServer.Dispose();
                httpServer = null;
            }
        }
        public static IHttpTestServer Create(HttpConfiguration configuration = null) {
            return new HttpTestServer(configuration);
        }
    }

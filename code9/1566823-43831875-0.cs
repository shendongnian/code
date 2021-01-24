    public class TestServer : IServer, IDisposable
    {
        public HttpClient CreateClient()
        {
            HttpClient httpClient = new HttpClient(this.CreateHandler());
            ...
        }
    }

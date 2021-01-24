    public class SingleHttpClientInstanceController : ApiController {
        private readonly HttpClient HttpClient;
    
        public SingleHttpClientInstanceController(IHttpClientAcessor httpClientAccessor) {
            HttpClient = httpClientAccessor.HttpClient;
        }
    
        // This method uses the shared instance of HttpClient for every call to GetProductAsync.
        public async Task<Product> GetProductAsync(string id) {
            var hostName = HttpContext.Current.Request.Url.Host;
            var result = await HttpClient.GetStringAsync(string.Format("http://{0}:8080/api/...", hostName));
            return new Product { Name = result };
        }
    }

    public class SearchService : ISomeSearchService
    {
        private readonly IHttpClient httpClient;
        public SearchService(IHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }

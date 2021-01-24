    public interface ICustomSearchIndexClient
    {
        DocumentSearchResult<T> Search<T>(string searchTerm, SearchParameters parameters) where T : class;
    }
    public class CustomSearchIndexClient : ICustomSearchIndexClient
    {
        private readonly SearchIndexClient _searchIndexClient;
        public CustomSearchIndexClient(string searchServiceName, string indexName, string apiKey)
        {
            _searchIndexClient = new SearchIndexClient(searchServiceName, indexName, new SearchCredentials(apiKey));
        }
        public DocumentSearchResult<T> Search<T>(string searchTerm, SearchParameters parameters) where T: class
        {
            return _searchIndexClient.Documents.Search<T>(searchTerm, parameters);
        }
    }

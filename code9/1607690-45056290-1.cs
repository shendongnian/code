    public class SearchController : ApiController {
    
        private readonly ISearchClient indexClient;
    
        public SearchController(ISearchClient client) {
            indexClient = client; // dependency injected
        }
    
        public IEnumerable<string> Get(string keyword){
            return indexClient.Search(keyword);
        }
    }

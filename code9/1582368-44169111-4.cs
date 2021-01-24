    [RoutePrefix("api/search")]
    public class SearchController : ApiController {
        [HttpGet]
        [Route("{*searchValue}", Name = "GenericSearch")] // Matches GET api/Seach/{anything here}
        [ResponseType(typeof(SearchResponse))]
        public async Task<IHttpActionResult> Search(string searchValue) {
            //...
        }
    }

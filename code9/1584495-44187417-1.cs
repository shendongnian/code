    public class GetDocumentsController : ApiController
    {
        // POST /api/GetDocuments
        [HttpPost]
        public GetDocumentsResponse Post([FromBody]GetDocumentsRequest request) { ... }
    }
    public class FinishDocumentsController : ApiController 
    {
        // POST /api/FinishDocuments/
        [HttpPost]
        public FinishDocumentsResponse Post([FromBody] FinishDocumentsRequest request){ ...}
    }

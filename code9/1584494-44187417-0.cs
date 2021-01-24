    public class DocumentController : ApiController 
    {
        // POST /api/Document/GetDocuments
        [HttpPost]
        [Route("GetDocuments")]
        public GetDocumentsResponse Post([FromBody]GetDocumentsRequest request) { ... }
    
        // POST /api/Document/FinishDocuments
        [HttpPost]
        [Route("FinishDocuments")]
        public FinishDocumentsResponse Post([FromBody] FinishDocumentsRequest request){ ...}
    }

    public class DocumentController : ApiController {
    
        [HttpPost]
        public async Task<IHttpActionResult> CreateDocument([FromBody]List<DocumentDetails> details) {
            //...
        }
    
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]AppDocument document) {
            //...
        }
    }

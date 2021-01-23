    [RoutePrefix("api/Documenten")]
    public class DocumentenController : ApiController {
        //eg POST api/documenten/deletedocument/testing/10600349
        [HttpPost]
        [Route("DeleteDocument/{name}/{planId}")]
        public IHttpActionResult DeleteDocument(string name, int planId) {
          _documentenProvider.DeleteDocument(planId, name);
          return Ok();
        }
    }

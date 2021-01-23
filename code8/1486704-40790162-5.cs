    [RoutePrefix("api/v1/jobs")]
    public class JobsController : ApiController {
        //POST api/v1/jobs/PostInactiveStatus
        [ActionName("PostInactiveStatus")]
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("PostInactiveStatus")] //<-- this was missing
        public IHttpActionResult PostInactiveStatus(Job job) { ...}
    }

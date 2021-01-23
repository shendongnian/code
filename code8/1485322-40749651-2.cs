    [RoutePrefix("api/tdatasubdate")]
    public class TDataSubDateController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Getdetails([FromUri]string ROOM, [FromUri]string STATUS_TYPE, [FromUri]DateTime? SUBDATE_GT = null, [FromUri]DateTime? SUBDATE_LT = null)
        {
            return Ok(string.Format("Room {0} Details", ROOM));
        }
    }

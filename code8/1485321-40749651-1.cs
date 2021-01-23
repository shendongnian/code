    [RoutePrefix("api/tdata")]
    public class TDataController : ApiController
    {        
        [HttpGet]
        [Route("{ROOM}/preview")]
        public IHttpActionResult Getdetails(string ROOM, [FromUri]DateTime DOB_GT, [FromUri]DateTime DOB_LT, [FromUri]string STATUS_TYPE)
        { 
            return Ok(string.Format("Room {0} Preview", ROOM));
        }
        [HttpGet]
        [Route("{ROOM}/details")]
        public IHttpActionResult Getdetails(string ROOM, [FromUri]string STATUS_TYPE, [FromUri]DateTime? SUBDATE_GT = null, [FromUri]DateTime? SUBDATE_LT = null)
        {
            return Ok(string.Format("Room {0} Details", ROOM));
        }
    }
